output "public_ip_address" {
  description = "The public IP address assigned to the app public ip NIC"
  value       = azurerm_public_ip.app_public_ip.ip_address
}

output "private_ip_address" {
  description = "The private IP address assigned to the app interface NIC"
  value       = azurerm_network_interface.app_interface.private_ip_address
}
