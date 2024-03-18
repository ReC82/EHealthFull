resource "azurerm_windows_virtual_machine" "vm-example" {
  name                = "APP-EHEALTH"
  resource_group_name = var.app_ressource_group_name
  location            = var.app_location
  size                = "Standard_F2"
  admin_username      = "rootUser"
  admin_password      = "P@ssw0rd!123"
  network_interface_ids = [
    azurerm_network_interface.nic_example.id,
  ]

  os_disk {
    caching              = "ReadWrite"
    storage_account_type = "Standard_LRS"
  }

  source_image_reference {
    publisher = "MicrosoftWindowsServer"
    offer     = "WindowsServer"
    sku       = "2016-Datacenter"
    version   = "latest"
  }
}