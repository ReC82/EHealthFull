#####################
# SSH KEY
#####################
resource "tls_private_key" "eheal" {
  algorithm = "RSA"
  rsa_bits  = 4096
}

