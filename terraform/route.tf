resource "aws_route_table" "public_az1_rtb" {
  vpc_id = aws_vpc.main-vpc.id

  route {
    gateway_id = aws_internet_gateway.igw.id
    cidr_block = "0.0.0.0/0"
  }

  tags = {
    Name = "${var.environment}-${var.component_name}-vpc-public-az1-rtb"
  }
}

resource "aws_route_table_association" "public-az1-rta" {
  subnet_id      = aws_subnet.public-subnets[0].id
  route_table_id = aws_route_table.public_az1_rtb.id
}
