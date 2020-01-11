using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arkitekten.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectOwnerUserName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "OrderedProducts",
                columns: table => new
                {
                    OrderedProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductType = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    OrderPlaced = table.Column<DateTime>(nullable: false),
                    Retailer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProducts", x => x.OrderedProductId);
                    table.ForeignKey(
                        name: "FK_OrderedProducts_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_ProjectId",
                table: "OrderedProducts",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedProducts");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
