

resource "random_string" "db_account_name" {
  length  = 20
  upper   = false
  special = false
  numeric = false
}

resource "random_string" "storage_account_name" {
  length  = 12
  special = false
  numeric = false
  upper   = false
}

resource "random_string" "api_management_suffix" {
  length  = 12
  special = false
  numeric = false
  upper   = false
}

resource "random_uuid" "user_id" {

}

resource "azurerm_resource_group" "resource_group" {
  location = var.location
  name     = var.resource_group_name
}

resource "azurerm_cosmosdb_account" "db_account" {
  name                      = random_string.db_account_name.id
  location                  = var.location
  resource_group_name       = azurerm_resource_group.resource_group.name
  offer_type                = "Standard"
  kind                      = "GlobalDocumentDB"
  enable_automatic_failover = false
  geo_location {
    location          = var.location
    failover_priority = 0
  }
  consistency_policy {
    consistency_level       = "BoundedStaleness"
    max_interval_in_seconds = 300
    max_staleness_prefix    = 100000
  }
  depends_on = [
    azurerm_resource_group.resource_group
  ]
}

resource "azurerm_storage_account" "storage_account" {
  name                     = "${random_string.storage_account_name.id}storage"
  resource_group_name      = azurerm_resource_group.resource_group.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "deployments" {
  name                  = "function-releases"
  storage_account_name  = azurerm_storage_account.storage_account.name
  container_access_type = "private"
}

data "azurerm_storage_account_sas" "sas" {
  connection_string = azurerm_storage_account.storage_account.primary_connection_string
  https_only        = true
  start             = "2019-01-01"
  expiry            = "2023-12-31"

  resource_types {
    object    = true
    container = false
    service   = false
  }
  services {
    blob  = true
    queue = false
    table = false
    file  = false
  }
  permissions {
    read    = true
    write   = false
    delete  = false
    list    = false
    add     = false
    create  = false
    update  = false
    process = false
  }
}

resource "azurerm_application_insights" "application_insights" {
  name                = "${var.project}-${var.environment}-application-insights"
  location            = var.location
  resource_group_name = azurerm_resource_group.resource_group.name
  application_type    = "web"
}

resource "azurerm_api_management" "api_management" {
  name                = "${var.project}-api-management-${random_string.api_management_suffix.id}"
  location            = var.location
  resource_group_name = var.resource_group_name
  publisher_name      = "Lee Wilson"
  publisher_email     = "lee.wilson@nimbleapproach.com"
  sku_name            = "Developer_1"
}

resource "azurerm_api_management_product" "shopping_list_product" {
  product_id            = "shoppinglistproduct"
  api_management_name   = azurerm_api_management.api_management.name
  resource_group_name   = azurerm_resource_group.resource_group.name
  display_name          = "Shopping List Product"
  subscription_required = true
  approval_required     = false
  published             = true
}

resource "azurerm_api_management_user" "ui_user" {
  api_management_name = azurerm_api_management.api_management.name
  resource_group_name = var.resource_group_name
  user_id             = random_uuid.user_id.id
  first_name          = "Lee"
  last_name           = "Wilson"
  email               = "lee.wilson+ui@nimbleapproach.com"
}

resource "azurerm_api_management_subscription" "ui_subscription" {
  api_management_name = azurerm_api_management.api_management.name
  resource_group_name = var.resource_group_name
  user_id             = azurerm_api_management_user.ui_user.id
  product_id          = azurerm_api_management_product.shopping_list_product.id
  display_name        = "UI Subscription"
}