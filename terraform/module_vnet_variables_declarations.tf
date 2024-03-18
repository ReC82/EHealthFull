variable "subnet_names" {
  type        = list(string)
  description = "List of subnets names"
}

variable "subnet_prefixes" {
  description = "The address prefix to use for the subnets"
  type        = list(string)
}