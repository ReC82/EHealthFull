# Public IP
# .NET
# SUBNET 1

/*
# Add in /Module_vnet/ouputs

output "app_interface_ids" {
  value = azurerm_network_interface.app_interface[*].id
}

# Add in this module if associations created in this module 
module "main_app_vnet" {
    source          = "./Module_vnet"

    # Recover network interface IDs exported from Module_vnet
    app_interface_ids = module.main_app_vnet.app_interface_ids
}
*/

# Create Resource Group rg_ehealth
resource "azurerm_resource_group" "rg_ehealth"{
    name = var.nsg_rg_group_name
    location = var.nsg_rg_location

    tags = {
        environment = var.nsg_tags
    }
}

# Create Network Security Group and rule nsg1_app
resource "azurerm_network_security_group" "nsg_app" {
    name                = var.nsg_app_name
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    security_rule {
        name                       = "app-HTTP"
        priority                   = 1001
        direction                  = "Inbound"
        access                     = "Allow"
        protocol                   = "Tcp"
        source_port_range          = "*"
        destination_port_range     = "80"
        source_address_prefix      = "*"
        destination_address_prefix  = "10.0.1.100/32"
    }

    tags = var.nsg_tags
}

# Create Network Security Group and rule nsg2_api
resource "azurerm_network_security_group" "nsg_api_java" {
    name                = var.nsg_api_java_name
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    security_rule {
        name                       = "api-java-HTTP"
        priority                   = 1001
        direction                  = "Inbound"
        access                     = "Allow"
        protocol                   = "Tcp"
        source_port_range          = "*"
        destination_port_range     = "80"
        source_address_prefix      = "10.0.1.100/32"
        destination_address_prefix = "10.0.2.150/32"
    }

    tags = var.nsg_tags
}

# Create Network Security Group and rule nsg3_db
resource "azurerm_network_security_group" "nsg_db_mysql" {
    name                = var.nsg_db_mysql_name
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    security_rule {
        name                       = "db-mysql-HTTP"
        priority                   = 1001
        direction                  = "Inbound"
        access                     = "Allow"
        protocol                   = "Tcp"
        source_port_range          = "*"
        destination_port_range     = "3306"
        source_address_prefix      = "10.0.2.150/32"
        destination_address_prefix = "10.0.3.200/32"
    }

    tags = var.nsg_tags
}


/* 

resource "azurerm_network_interface_security_group_association" "ass_nsg_app_int_app" {
    network_interface_id      = module.main_app_vnet.app_interface_ids[0]  
    network_security_group_id = azurerm_network_security_group.nsg_app.id
}

resource "azurerm_network_interface_security_group_association" "ass_nsg_api_int_api" {
    network_interface_id      = module.main_app_vnet.app_interface_ids[1]  
    network_security_group_id = azurerm_network_security_group.nsg_api.id 
}

resource "azurerm_network_interface_security_group_association" "ass_nsg_db_int_db" {
    network_interface_id      = module.main_app_vnet.app_interface_ids[2]  
    network_security_group_id = azurerm_network_security_group.nsg_db.id 
}


*/





