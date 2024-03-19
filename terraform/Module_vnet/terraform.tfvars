resource_group_name          = "app-grp"
location                     = "centralus"
vnet1_name                   = "vnetwork-1"
vnet2_name                   = "vnetwork-2"
vnet1_address_space          = ["10.10.0.0/16"]
vnet2_address_space          = ["10.11.0.0/16"]
subnet1_address_prefix       = "10.10.1.0/24"
subnet2_address_prefix       = "10.10.2.0/24"
subnet1_vnet2_address_prefix = "10.11.1.0/24"
subnet2_vnet2_address_prefix = "10.11.2.0/24"

