﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pastry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcceptedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FulfilledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Pastry",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    PastryID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Pastry", x => new { x.OrderID, x.PastryID });
                    table.ForeignKey(
                        name: "FK_Order_Pastry_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Pastry_Pastry_PastryID",
                        column: x => x.PastryID,
                        principalTable: "Pastry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Adam", "Nowak" },
                    { 2, "Aleksandra", "Wiśniewska" }
                });

            migrationBuilder.InsertData(
                table: "Pastry",
                columns: new[] { "ID", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Drożdzówka", 3.3m, "A" },
                    { 2, "Babka cytrynowa", 21.23m, "B" },
                    { 3, "Jagodzianka", 7.2m, "A" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "ID", "AcceptedAt", "ClientID", "Comments", "EmployeeID", "FulfilledAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum ...", 2, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum ...", 1, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Order_Pastry",
                columns: new[] { "OrderID", "PastryID", "Amount", "Comments" },
                values: new object[,]
                {
                    { 1, 1, 3, null },
                    { 1, 3, 4, "Lorem ipsum ..." },
                    { 2, 1, 12, null },
                    { 2, 2, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Pastry_PastryID",
                table: "Order_Pastry",
                column: "PastryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Pastry");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pastry");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
