output "public_ip_address" {
  description = "The public IP address assigned to the Azure resource"
  value       = azurerm_public_ip.app_public_ip.ip_address
}
