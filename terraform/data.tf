data "aws_ssm_parameter" "inbound_ips" {
    name = "/NHS/dev-${data.aws_caller_identity.current.account_id}/tf/inbound_ips"
}

data "aws_ssm_parameter" "agent_ips" {
    name = "/NHS/deductions-${data.aws_caller_identity.current.account_id}/gocd-prod/agent_ips"
}

data "aws_ssm_parameter" "root_zone_id" {
  name = "/NHS/deductions-${data.aws_caller_identity.current.account_id}/root_zone_id"
}

data "aws_caller_identity" "current" {}
