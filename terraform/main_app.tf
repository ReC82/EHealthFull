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
  name     = var.app_ressource_group_name
  location = var.app_location
}

###############
# MODULE : VNET
###############
module "main_app_vnet" {
  source          = "./Module_vnet"
  subnet_names    = var.subnet_names
  subnet_prefixes = var.subnet_prefixes
}

###############
# MODULE : DATABASE
###############
module "main_app_database" {

  source = "./Module_Database"

  app_ressource_group_name = var.app_ressource_group_name
  app_location             = var.app_location

  db_srv_name     = var.db_srv_name
  db_pass         = var.db_pass
  db_root_user    = var.db_root_user
  db_disk_caching = var.db_disk_caching
  db_nic_id       = ["${module.main_app_vnet.database_nic}"]

  depends_on = [azurerm_resource_group.rg_ehealth]
}

####################
# MODULE : IIS
####################

module "main_app_web_server" {
  app_location             = var.app_location
  app_ressource_group_name = var.app_ressource_group_name

  iis_nic_id = ["${module.main_app_vnet.database_nic}"]

  source             = "./Module_IIS_Server"
  iis_server_name    = var.iis_server_name
  iis_server_size    = var.iis_server_size
  iis_admin_username = var.iis_admin_username
  iis_admin_password = var.iis_admin_password

  depends_on = [azurerm_resource_group.rg_ehealth]
}

###############
# MODULE : API
###############
module "main_app_api" {

  source = "./Module_API_Server"

  app_ressource_group_name = var.app_ressource_group_name
  app_location             = var.app_location

  api_srv_name     = var.api_srv_name
  api_pass         = var.api_pass
  api_root_user    = var.api_root_user
  api_disk_caching = var.api_disk_caching
  api_nic_id       = ["${module.main_app_vnet.database_nic}"]

  depends_on = [azurerm_resource_group.rg_ehealth]
}

#################################
# MODULE : NETWORK SECURITY GROUP
#################################
module "main_app_secgroup" {
    source              = "./Module_Security-Group"

     # Variable for Resource Group
    nsg_rg_group_name   = var.app_ressource_group_name
    nsg_rg_location     = var.app_location
  
    # Variable for Network Security Group
    nsg_app_name        = var.nsg_app
    nsg_api_java_name   = var.nsg_api_java
    nsg_db_mysql_name   = var.nsg_db_mysql  
  
    # Variable Environment
    nsg_tags            = var.nsg_tags

    # Recover network security group IDs exported from Module_Security-Group
    nsg_ids             = module.main_app_secgroup.nsg_ids
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
*/

