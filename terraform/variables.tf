variable "region" {
  type = string
  default = "eu-west-2"
}

variable "task_family" {}
variable "task_execution_role" {}

variable "task_container_name" {}
variable "task_image_name" {}
variable "task_cpu" {}
variable "task_memory" {}
variable "task_container_port" {}
variable "task_host_port" {}

variable "service_container_port" {}
variable "service_container_name" {}
variable "service_desired_count" {}

variable "environment" {
  type = string
}

variable "component_name" {
  type = string
}

variable "cidr" {
  type = string
}

variable "public_subnets" {
  type = list
}

variable "azs" {
  type = list
}

variable "task_image_tag" {
  default = "latest"
}
