data "archive_file" "file_function_app" {
  type = "zip"
  source_dir = "./publish/recipe-api-function"
  output_path = var.recipefunctionzip
}

data "azurerm_function_app_host_keys" "recipe_api_key" {
  name = azurerm_function_app.recipe_api_function.name
  resource_group_name = var.resource_group_name
}

resource "azurerm_function_app" "recipe_api_function" {
  name = "${var.project}-${var.environment}-recipe-api-function"
  resource_group_name = azurerm_resource_group.resource_group.name
  location = var.location
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "https://${azurerm_storage_account.storage_account.name}.blob.core.windows.net/${azurerm_storage_container.deployments.name}/${azurerm_storage_blob.storage_blob.name}${data.azurerm_storage_account_sas.sas.sas}"
    "FUNCTIONS_WORKER_RUNTIME" = "dotnet"
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.application_insights.instrumentation_key
    "DatabaseName" = var.environment
    "PrimaryConnectionString" = azurerm_cosmosdb_account.db_account.connection_strings[0]
    "HASH" =  "${filebase64sha256(var.recipefunctionzip)}"
  }
  os_type = "linux"
  site_config {}  
  storage_account_name = azurerm_storage_account.storage_account.name
  storage_account_access_key = azurerm_storage_account.storage_account.primary_access_key
  version = "~4"
}

resource "azurerm_app_service_plan" "app_service_plan" {
  name = "${var.project}-${var.environment}-app-service-plan"
  resource_group_name = azurerm_resource_group.resource_group.name
  location = var.location
  kind = "FunctionApp"
  reserved = true
  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_storage_blob" "storage_blob" {
  name = "recipe-api-function.zip"
  storage_account_name = azurerm_storage_account.storage_account.name
  storage_container_name = azurerm_storage_container.deployments.name
  type = "Block"
  source = var.recipefunctionzip
  content_md5 = filemd5(var.recipefunctionzip)
}

resource "azurerm_api_management_api" "recipe_api" {
  name = "${var.project}-recipe-api-${random_string.api_management_suffix.id}"
  resource_group_name = var.resource_group_name
  api_management_name = azurerm_api_management.api_management.name
  revision = "2"
  display_name = "${var.project}-recipe-api"
  protocols = ["http", "https"]
  
  import {
    content_format = "swagger-link-json"
    content_value = "https://${azurerm_function_app.recipe_api_function.name}.azurewebsites.net/api/swagger.json"
  }
}

resource "azurerm_api_management_backend" "recipe_api_backend" {
  name = "${var.project}-recipe-api-backend-${random_string.api_management_suffix.id}"
  resource_group_name = var.resource_group_name
  api_management_name = azurerm_api_management.api_management.name
  protocol = "http"
  url = "https://${azurerm_function_app.recipe_api_function.name}.azurewebsites.net/api/"

  credentials {
    header = {
      "x-functions-key" = data.azurerm_function_app_host_keys.recipe_api_key.default_function_key
    }
  }
}

resource "azurerm_api_management_api_policy" "recipe_api_policy" {
  api_name = azurerm_api_management_api.recipe_api.name
  api_management_name = azurerm_api_management.api_management.name
  resource_group_name = var.resource_group_name

  xml_content = <<XML
  <policies>
    <inbound>
      <base/>
      <set-backend-service backend-id="${azurerm_api_management_backend.recipe_api_backend.name}" />
    </inbound>
  </policies>
  XML
}

resource "azurerm_api_management_product_api" "shopping_list_product_recipe_api" {
  api_name = azurerm_api_management_api.recipe_api.name
  product_id = azurerm_api_management_product.shopping_list_product.product_id
  api_management_name = azurerm_api_management.api_management.name
  resource_group_name = var.resource_group_name
}
