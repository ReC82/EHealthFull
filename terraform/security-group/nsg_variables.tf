# SERVER_NAMES
# VNET (10.0.0.0/16)
# SUBNETS : NAMES, IP_RANGES (10.0.1-2-3 / 24)


# Variable for azurerm_network_security_group
variable "rg_ehealth_name" {
    type        = string
    default     = ""
    description = "RG name in Azure"
}

variable "rg_ehealth_location" {
    type        = string
    default     = "" 
    description = "RG location in Azure"
}

variable "nsg1_ehealth_name" {
    type        = string
    default     = ""
    description = "NSG 1 Ehealth in Azure"
}

variable "nsg2_ehealth_name" {
    type        = string
    default     = ""
    description = "NSG 2 Ehealth in Azure"
}

variable "nsg3_ehealth_name" {
    type        = string
    default     = ""
    description = "NSG 3 Ehealth in Azure"
}

variable "network_interface_name" {
    type        = string
    default     = ""
    description = "Network interface name Ehealth in Azure"
}



