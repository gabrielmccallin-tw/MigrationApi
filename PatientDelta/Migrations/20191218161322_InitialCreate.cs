using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDelta.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    NhsNumber = table.Column<string>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    Requester = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.NhsNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
