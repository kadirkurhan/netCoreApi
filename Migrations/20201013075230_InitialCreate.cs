using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netCoreWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyCountry = table.Column<string>(nullable: true),
                    CompanyCity = table.Column<string>(nullable: true),
                    CompanyTown = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    LastControlDate = table.Column<DateTime>(nullable: false),
                    WillControl = table.Column<bool>(nullable: false),
                    IsOffer = table.Column<bool>(nullable: false),
                    PriceOffer = table.Column<int>(nullable: false),
                    ActiveOrNot = table.Column<bool>(nullable: false),
                    DebtAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
