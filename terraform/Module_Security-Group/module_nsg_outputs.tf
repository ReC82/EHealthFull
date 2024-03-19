output "nsg_ids" {
  type = map(string)
    default = {
      "app"      = azurerm_network_security_group.nsg_app.id ,
      "api_java" = azurerm_network_security_group.nsg_api_java.id , 
      "db_mysql" = azurerm_network_security_group.nsg_db_mysql.id
    }
}