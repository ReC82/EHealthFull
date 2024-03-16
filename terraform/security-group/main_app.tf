# Public IP
# .NET
# SUBNET 1

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
    }

    tags = {
        environment = var.nsg_tags
    }
}

# Create Network Security Group and rule nsg2_api
resource "azurerm_network_security_group" "nsg_api" {
    name                = var.nsg_api_name
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    security_rule {
        name                       = "api-HTTP"
        priority                   = 1001
        direction                  = "Inbound"
        access                     = "Allow"
        protocol                   = "Tcp"
        source_port_range          = "*"
        destination_port_range     = "80"
        source_address_prefix      = "10.0.1.100/32"
    }

    tags = {
        environment = var.nsg_tags
    }
}

# Create Network Security Group and rule nsg3_db
resource "azurerm_network_security_group" "nsg_db" {
    name                = var.nsg_db_name
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    security_rule {
        name                       = "db-HTTP"
        priority                   = 1001
        direction                  = "Inbound"
        access                     = "Allow"
        protocol                   = "Tcp"
        source_port_range          = "*"
        destination_port_range     = "3306"
        source_address_prefix      = "10.0.2.150/32"
    }

    tags = {
        env = var.nsg_tags
    }
}

# Create network interface
resource "azurerm_network_interface" "app-nic" {
    name                = var.network_interface_name
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    ip_configuration {
        name                          = "internal"
        subnet_id                     = azurerm_subnet.subnet_id.id
        private_ip_address_allocation = "Dynamic"
        public_ip_address_id          = azurerm_public_ip.public_ip.id
    }

    tags = {
        environment = var.nsg_tags
    }
}

# Connect the security group to the network interface
resource "azurerm_network_interface_security_group_association" "association" {
    network_interface_id      = azurerm_network_interface.app-nic.id
    network_security_group_id = azurerm_network_security_group.nsg1_app_ehealth.id
}



