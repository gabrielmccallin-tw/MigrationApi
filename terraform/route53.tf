locals {
  alb_dns = aws_alb.alb.dns_name
  zone_id = data.aws_ssm_parameter.root_zone_id.value
}

resource "aws_route53_record" "cname-r53-record" {
  zone_id = local.zone_id
  name    = "${var.environment}.prm"
  type    = "CNAME"
  ttl     = "300"
  records = [local.alb_dns]
}
