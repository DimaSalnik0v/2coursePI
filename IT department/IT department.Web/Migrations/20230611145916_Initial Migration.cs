using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_department.Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Printers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    repair_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false),
                    id_service_company = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_companies",
                columns: table => new
                {
                    Id_company = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    legal_addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone_number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_companies", x => x.Id_company);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Printers");

            migrationBuilder.DropTable(
                name: "Service_companies");
        }
    }
}
