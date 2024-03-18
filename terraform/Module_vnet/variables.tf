variable "resource_group_name" {
  description = "Name of the Azure resource group"
  default     = "app-grp"
}

variable "location" {
  description = "Location for all Azure resources"
  default     = "centralus"
}

variable "address_space" {
  type        = list(string)
  description = "The address space that is used by the virtual network"
  default     = ["10.0.0.0/16"]
}

variable "subnet_prefixes" {
  description = "The address prefix to use for the subnet"
  type        = list(string)
  default     = ["10.0.1.0/24"]
}

variable "subnet_names" {
  description = "A list of subnet names inside the vNet"
  type        = list(string)
}
