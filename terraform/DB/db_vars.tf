variable "db_pass" {
    description = "mysql root pwd"
    sensitive = true
}

variable "db_root_user" {
    description = "mysql root user"
    sensitive = true
}   

variable "db_srv_name" {
    description = "DB Server Name"
    default = "SRV_DB"
}

variable "db_srv_size" {
    default = "Standard_DS1_v2"
}

variable "db_srv_disk_name" {
    default = "DISK_DB_EHEALTH"
}

variable "db_srv_disk_storage_account_type" {
    default = "Premium_LRS"
}

variable "db_srv_distrib" {
    default = "UbuntuServer"
}

variable "db_srv_distrib_sku" {
    default = "18.04-LTS"
}

variable "db_srv_distrib_version" {
    default = "latest"
}