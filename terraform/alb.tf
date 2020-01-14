resource "aws_alb" "alb" {
  name            = "${var.environment}-${var.component_name}-alb"
  subnets         = [aws_subnet.public-subnets[0].id,
                     aws_subnet.public-subnets[1].id]

  security_groups = [aws_security_group.lb-sg.id]
}

resource "aws_alb_target_group" "alb-tg" {
  name                  = "${var.environment}-${var.component_name}-alb-tg"
  port                  = 5000
  protocol              = "HTTP"
  vpc_id                = aws_vpc.main-vpc.id
  target_type           = "ip"
  deregistration_delay  = 20
}

resource "aws_alb_listener" "alb-listener-http" {
  load_balancer_arn = aws_alb.alb.arn
  port              = "80"
  protocol          = "HTTP"

  default_action {
    target_group_arn = aws_alb_target_group.alb-tg.arn
    type             = "forward"
  }
}
