# MYSQL
# SET ROOT PWD - NO REMOTE LOGIN
# SET DBUSER

###########################
# DB VM
###########################

resource "azurerm_linux_virtual_machine" "ehealth_db_srv" {
  name                            = var.db_srv_name
  location                        = azurerm_resource_group.rg_linux.location
  network_interface_ids           = [azurerm_network_interface.netint_db_linux.id]
  admin_username                  = var.db_root_user
  disable_password_authentication = false
  admin_password = var.db_pass
  resource_group_name             = azurerm_resource_group.rg_linux.name
  size                            = var.db_srv_size
  os_disk {
    name                 = var.db_srv_disk_name
    caching              = "ReadWrite"
    storage_account_type = var.db_srv_disk_storage_account_type
  }

  source_image_reference {
    publisher = "Canonical"
    offer     = var.db_srv_distrib
    sku       = var.db_srv_distrib_sku
    version   = var.db_srv_distrib_version
  }

  computer_name = "EHEALTH-PROD-DB"

  admin_ssh_key {
    username   = var.db_root_user
    public_key = tls_private_key.ssh_ehealth.public_key_openssh
  }

  boot_diagnostics {
    storage_account_uri = azurerm_storage_account.storacc_db_linux.primary_blob_endpoint
  }

  tags = {
    env = "prod"
  }
}