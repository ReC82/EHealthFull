# Create the Azure resource group
resource "azurerm_resource_group" "rg" {
  name     = var.resource_group_name
  location = var.location
}

# Create the first virtual network
resource "azurerm_virtual_network" "vnet1" {
  name                = var.vnet1_name
  location            = var.location
  resource_group_name = azurerm_resource_group.rg.name
  address_space       = var.vnet1_address_space

  subnet {
    name           = "subnet1"
    address_prefix = var.subnet1_address_prefix
  }

  subnet {
    name           = "subnet2"
    address_prefix = var.subnet2_address_prefix
  }

  tags = {
    environment = "vnet1"
  }
}

# Create the second virtual network
resource "azurerm_virtual_network" "vnet2" {
  name                = var.vnet2_name
  location            = var.location
  resource_group_name = azurerm_resource_group.rg.name
  address_space       = var.vnet2_address_space

  subnet {
    name           = "subnet1"
    address_prefix = var.subnet1_vnet2_address_prefix
  }

  subnet {
    name           = "subnet2"
    address_prefix = var.subnet2_vnet2_address_prefix
  }

  tags = {
    environment = "vnet2"
  }
}

# Create peering connections between virtual networks
resource "azurerm_virtual_network_peering" "peering-1" {
  name                      = "peer1to2"
  resource_group_name       = azurerm_resource_group.rg.name
  virtual_network_name      = azurerm_virtual_network.vnet1.name
  remote_virtual_network_id = azurerm_virtual_network.vnet2.id
}

resource "azurerm_virtual_network_peering" "peering-2" {
  name                      = "peer2to1"
  resource_group_name       = azurerm_resource_group.rg.name
  virtual_network_name      = azurerm_virtual_network.vnet2.name
  remote_virtual_network_id = azurerm_virtual_network.vnet1.id
}

locals {
  out_subnet_id = azurerm_virtual_network.vnet1.subnet.*.id
}

# Create a static public IP address
resource "azurerm_public_ip" "app_public_ip" {
  name                = "acceptanceTest"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  allocation_method   = "Static"

  tags = {
    environment = "app_public_ip"
  }
}

# Create a network interface
resource "azurerm_network_interface" "app_interface" {
  name                = "app-public-ip"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = local.out_subnet_id[0]
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.app_public_ip.id
  }
}
