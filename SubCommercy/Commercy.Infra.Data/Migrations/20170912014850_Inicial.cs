using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Commercy.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressCustomer = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    DtaBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameCustomer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NumberPersonalDocument = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtaContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "AccountShopping",
                columns: table => new
                {
                    AccountShoppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveAccountShopping = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CustomerIdAccountShopping = table.Column<int>(type: "int", nullable: false),
                    DtaAccountShopping = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountShopping", x => x.AccountShoppingId);
                    table.ForeignKey(
                        name: "FK_AccountShopping_Customer_CustomerIdAccountShopping",
                        column: x => x.CustomerIdAccountShopping,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingExecuted",
                columns: table => new
                {
                    ShoppingExecutedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountShoppingExecutedId = table.Column<int>(type: "int", nullable: false),
                    DtaShopping = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusShopping = table.Column<bool>(type: "bit", nullable: false),
                    TotalShopping = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingExecuted", x => x.ShoppingExecutedId);
                    table.ForeignKey(
                        name: "FK_ShoppingExecuted_AccountShopping_AccountShoppingExecutedId",
                        column: x => x.AccountShoppingExecutedId,
                        principalTable: "AccountShopping",
                        principalColumn: "AccountShoppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountShopping_CustomerIdAccountShopping",
                table: "AccountShopping",
                column: "CustomerIdAccountShopping",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingExecuted_AccountShoppingExecutedId",
                table: "ShoppingExecuted",
                column: "AccountShoppingExecutedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ShoppingExecuted");

            migrationBuilder.DropTable(
                name: "AccountShopping");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
