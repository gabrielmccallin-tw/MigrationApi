environment          = "dev"
component_name       = "prm-migration-poc"

task_execution_role  = "ecsTaskExecutionRole"
task_family          = "prm"

task_container_name  = "prm-migration-poc"
task_image_name      = "prm/prm-migration-poc"
task_cpu             = 256
task_memory          = 512
task_container_port  = 5000
task_host_port       = 5000

service_container_port  = "5000"
service_container_name  = "prm-migration-poc"
service_desired_count   = "1"

region                              = "eu-west-2"

cidr              = "10.50.0.0/16"
public_subnets    = ["10.50.1.0/24", "10.50.2.0/24"]
azs               = ["eu-west-2a", "eu-west-2b"]
