﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StockID",
                table: "Comment",
                column: "StockID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
