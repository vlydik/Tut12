using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tut12.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectioneries",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PricePerItem = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectioneries", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_Orders",
                columns: table => new
                {
                    IdConfectionary = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Orders", x => x.IdConfectionary);
                    table.ForeignKey(
                        name: "FK_Confectionery_Orders_Confectioneries_IdConfectionary",
                        column: x => x.IdConfectionary,
                        principalTable: "Confectioneries",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_Orders_Orders_IdConfectionary",
                        column: x => x.IdConfectionary,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Orders");

            migrationBuilder.DropTable(
                name: "Confectioneries");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
