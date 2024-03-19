# SERVER_NAMES
# VNET (10.0.0.0/16)
# SUBNETS : NAMES, IP_RANGES (10.0.1-2-3 / 24)


# Variable for resource_group
variable "nsg_rg_group_name" {
    type        = string
    default     = ""
    description = "RG name in Azure"
}

variable "nsg_rg_location" {
    type        = string
    default     = "" 
    description = "RG location in Azure"
}

# Variable for network_security_group
variable "nsg_app_name" {
    type        = string
    default     = ""
    description = " APP NSG Ehealth in Azure"
}

variable "nsg_api_java_name" {
    type        = string
    default     = ""
    description = "API NSG Ehealth in Azure"
}

variable "nsg_db_mysql_name" {
    type        = string
    default     = ""
    description = "DB NSG Ehealth in Azure"
}


# Variable environement
variable "nsg_tags" {
    type = map(string)
    default = {
      "env" = "prod"
    }
     description = "Environment name for resource group Eahlth"
}



