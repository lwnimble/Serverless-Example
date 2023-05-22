data "archive_file" "file_function_app" {
  type = "zip"
  source_dir = "./publish/recipe-api-function"
  output_path = var.recipefunctionzip
}

resource "random_string" "random_string" {
  length = 12
  special = false  
  numeric = false
  upper = false
}

resource "azurerm_resource_group" "resource_group" {
  location = var.location
  name     = var.resource_group_name
}

resource "azurerm_storage_account" "storage_account" {
      name = "${random_string.random_string.id}storage"
      resource_group_name = azurerm_resource_group.resource_group.name
      location = var.location
      account_tier = "Standard"
      account_replication_type = "LRS"
}

resource "azurerm_storage_container" "deployments" {
  name = "function-releases"
  storage_account_name = azurerm_storage_account.storage_account.name
  container_access_type = "private"
}

resource "azurerm_storage_blob" "storage_blob" {
  name = "recipe-api-function.zip"
  storage_account_name = azurerm_storage_account.storage_account.name
  storage_container_name = azurerm_storage_container.deployments.name
  type = "Block"
  source = var.recipefunctionzip
}

data "azurerm_storage_account_sas" "sas" {
  connection_string = azurerm_storage_account.storage_account.primary_connection_string
  https_only = true
  start = "2019-01-01"
  expiry = "2023-12-31"

  resource_types {
          object = true
          container = false
          service = false
      }
      services {
          blob = true
          queue = false
          table = false
          file = false
      }
      permissions {
          read = true
          write = false
          delete = false
          list = false
          add = false
          create = false
          update = false
          process = false
    }
}

resource "azurerm_application_insights" "application_insights" {
  name = "${var.project}-${var.environment}-application-insights"
  location = var.location
  resource_group_name = azurerm_resource_group.resource_group.name
  application_type = "web"
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

resource "azurerm_function_app" "recipe_api_function" {
  name = "${var.project}-${var.environment}-recipe-api-function"
  resource_group_name = azurerm_resource_group.resource_group.name
  location = var.location
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "https://${azurerm_storage_account.storage_account.name}.blob.core.windows.net/${azurerm_storage_container.deployments.name}/${azurerm_storage_blob.storage_blob.name}${data.azurerm_storage_account_sas.sas.sas}"
    "FUNCTIONS_WORKER_RUNTIME" = "dotnet"
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.application_insights.instrumentation_key
  }
  os_type = "linux"
  site_config {}  
  storage_account_name = azurerm_storage_account.storage_account.name
  storage_account_access_key = azurerm_storage_account.storage_account.primary_access_key
  version = "~4"
}