output "recipe_api_function_name" {
  value       = azurerm_function_app.recipe_api_function.name
  description = "Deployed recipe api function name"
}

output "recipe_api_function_hostname" {
  value       = azurerm_function_app.recipe_api_function.default_hostname
  description = "Deployed recipe api host name"
}

output "cosmosdb_account_name" {
  value       = azurerm_cosmosdb_account.db_account.name
  description = "cosmos db account name"
  sensitive   = true
}

output "api_subscription_key" {
  value       = azurerm_api_management_subscription.ui_subscription.primary_key
  description = "Primary key for api subscription"
  sensitive   = true
}