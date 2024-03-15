# SERVER_NAMES
# VNET (10.0.0.0/16)
# SUBNETS : NAMES, IP_RANGES (10.0.1-2-3 / 24)

variable "app_location" {
    default = "centralus"
}

variable "resource_group_name" {
  description = "Name of the Azure resource group"
  default     = "app-grp"
}