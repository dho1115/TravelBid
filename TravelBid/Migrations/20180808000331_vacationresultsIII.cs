using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravelBid.Migrations
{
    public partial class vacationresultsIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VacationerModelFK",
                table: "NewVacationerModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReturnVacations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attractions = table.Column<string>(nullable: true),
                    BestTimeToGo = table.Column<string>(nullable: true),
                    DestinationName = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnVacations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnVacations");

            migrationBuilder.DropColumn(
                name: "VacationerModelFK",
                table: "NewVacationerModel");
        }
    }
}
