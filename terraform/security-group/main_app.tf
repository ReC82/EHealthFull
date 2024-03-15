# Public IP
# .NET
# SUBNET 1


resource "azurerm_resource_group" "rg_ehealth"{
    name = var.rg_ehealth_name
    location = var.rg_ehealth_location

    tags = {
        environment = "production"
    }
}

# Create Network Security Group and rule nsg1_ehealth
resource "azurerm_network_security_group" "nsg1_app_ehealth" {
  name                = var.nsg1_ehealth_name
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
    environment = "production"
  }
}


# Create Network Security Group and rule nsg2_ehealth
resource "azurerm_network_security_group" "nsg2_api_ehealth" {
  name                = var.nsg2_ehealth_name
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
    environment = "production"
  }
}

# Create Network Security Group and rule nsg3_ehealth
resource "azurerm_network_security_group" "nsg3_db_ehealth" {
  name                = var.nsg3_ehealth_name
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
    environment = "production"
  }
}

# Create network interface
resource "azurerm_network_interface" "app-nic" {
  name                = var.network_interface_name
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.subnet.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.public_ip.id
  }

  tags = {
    environment = "production"
  }
}

# Connect the security group to the network interface
resource "azurerm_network_interface_security_group_association" "association" {
  network_interface_id      = azurerm_network_interface.app-nic.id
  network_security_group_id = azurerm_network_security_group.nsg1_app_ehealth.id
}



