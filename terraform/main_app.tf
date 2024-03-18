# Public IP
# .NET
# SUBNET 1
/*
module "vnet" {
  source              = "github.com/ReC82/Terraform/tree/main/azure/lab04/module_vnet"
  rg_name             = var.ehealth_rg_name
  address_space_lab04 = ["10.0.0.0/16"]
  subnet_prefix_lab04 = ["10.0.1.0/24", "10.0.2.0/24", "10.0.3.0/24"]
  subnet_names_lab04  = ["sub1", "sub2", "sub3"]

}*/

resource "azurerm_resource_group" "rg_ehealth" {
  name     = var.db_rg_group_name
  location = var.app_location
}

module "main_app_database" {
  source           = "./Modules_Database"
  db_pass          = var.db_pass
  db_root_user     = var.db_root_user
  db_disk_caching  = var.db_disk_caching
  db_location      = var.db_location
  db_nic_id        = var.db_nic_id
  db_rg_group_name = var.db_rg_group_name
  //db_storage_account = var.db_storage_account
}

/*
module "secgroup" {
    source              = "./security-group"

     # Variable for Resource Group
    nsg_rg_group_name   = var.nsg_rg_group_name
    nsg_rg_location     = var.nsg_rg_location
  
    # Variable for Network Security Group
    nsg_app_name        = var.nsg_app
    nsg_api_name        = var.nsg_api
    nsg_db_name         = var.nsg_db  
  
    # Variable Environment
    nsg_tags            = var.nsg_tags
}

module "vnet" {
    source              = "./vnet"  
}
*/