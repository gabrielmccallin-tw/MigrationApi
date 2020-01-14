locals {
  ecs_cluster_id    = aws_ecs_cluster.ecs-cluster.id
  ecs_tasks_sg_id   = aws_security_group.ecs-tasks-sg.id
  public_subnets   = aws_subnet.public-subnets.*.id
  alb_tg_arn        = aws_alb_target_group.alb-tg.arn
}

resource "aws_ecs_service" "ecs-service" {
  name            = "${var.environment}-${var.component_name}-service"
  cluster         = local.ecs_cluster_id
  task_definition = aws_ecs_task_definition.task.arn
  desired_count   = var.service_desired_count
  launch_type     = "FARGATE"

  network_configuration {
    security_groups = [local.ecs_tasks_sg_id]
    subnets         = local.public_subnets
  }

  load_balancer {
    target_group_arn = local.alb_tg_arn
    container_name   = var.task_container_name
    container_port   = var.service_container_port
  }
}
