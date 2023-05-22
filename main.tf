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
    "WEBSITE_RUN_FROM_PACKAGE" = ""
    "FUNCTIONS_WORKER_RUNTIME" = "dotnet"
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.application_insights.instrumentation_key
  }
  os_type = "linux"
  site_config {}  
  storage_account_name = azurerm_storage_account.storage_account.name
  storage_account_access_key = azurerm_storage_account.storage_account.primary_access_key
  version = "~4"

  lifecycle {
    ignore_changes = [ 
      app_settings["WEBSITE_RUN_FROM_PACKAGE"]
     ]
  }
}