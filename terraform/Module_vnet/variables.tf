variable "resource_group_name" {
  description = "Name of the Azure resource group"
}

variable "location" {
  description = "Location for all Azure resources"
}

variable "vnet1_name" {
  description = "Name of the first virtual network"
}

variable "vnet2_name" {
  description = "Name of the second virtual network"
}

variable "vnet1_address_space" {
  description = "Address space for the first virtual network"
}

variable "vnet2_address_space" {
  description = "Address space for the second virtual network"
}

variable "subnet1_address_prefix" {
  description = "Address prefix for subnet1 in the first virtual network"
}

variable "subnet2_address_prefix" {
  description = "Address prefix for subnet2 in the first virtual network"
}

variable "subnet1_vnet2_address_prefix" {
  description = "Address prefix for subnet1 in the second virtual network"
}

variable "subnet2_vnet2_address_prefix" {
  description = "Address prefix for subnet2 in the second virtual network"
}
