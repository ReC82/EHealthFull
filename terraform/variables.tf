# SERVER_NAMES
# VNET (10.0.0.0/16)
# SUBNETS : NAMES, IP_RANGES (10.0.1-2-3 / 24)

variable "srv_app_name" {

}

variable "srv_api_name" {

}

variable "srv_db_name" {
  
}

variable "subnet_app_name" {

}

variable "subnet_app_ip_range" {
    type = list(string)
}

variable "subnet_db_name" {
  
}

variable "subnet_api_name" {
  
}

variable "vnet_name" {

}

variable "vnet_ip_ranges" {
  
}