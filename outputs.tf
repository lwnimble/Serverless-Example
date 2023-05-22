output "recipe_api_function_name" {
  value = azurerm_function_app.recipe_api_function.name
  description = "Deployed recipe api function name"
}

output "recipe_api_function_hostname" {
  value = azurerm_function_app.recipe_api_function.default_hostname
  description = "Deployed recipe api host name"
}