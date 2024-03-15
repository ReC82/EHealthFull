# SERVER_NAMES
# VNET (10.0.0.0/16)
# SUBNETS : NAMES, IP_RANGES (10.0.1-2-3 / 24)


# Variable for azurerm_network_security_group
variable "resource_groupe_name_rg_ehealth" {
    type        = string
    default     = ""
    description = "RG name in Azure"
}

variable "resource_group_location_rg_ehealth" {
    type        = string
    default     = "" 
    description = "RG location in Azure"
}

variable "network_security_group_name_nsg1_ehealth" {
    type        = string
    default     = ""
    description = "NSG 1 Ehealth in Azure"
}

variable "network_security_group_name_nsg2_ehealth" {
    type        = string
    default     = ""
    description = "NSG 2 Ehealth in Azure"
}

variable "network_security_group_name_nsg3_ehealth" {
    type        = string
    default     = ""
    description = "NSG 3 Ehealth in Azure"
}


