using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravelBid.Migrations
{
    public partial class runtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationRequestNamename",
                table: "newvacationrequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacationDetailsName",
                table: "newvacationrequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_newvacationrequest_DestinationRequestNamename",
                table: "newvacationrequest",
                column: "DestinationRequestNamename");

            migrationBuilder.AddForeignKey(
                name: "FK_newvacationrequest_DestinationRequests_DestinationRequestNamename",
                table: "newvacationrequest",
                column: "DestinationRequestNamename",
                principalTable: "DestinationRequests",
                principalColumn: "name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_newvacationrequest_DestinationRequests_DestinationRequestNamename",
                table: "newvacationrequest");

            migrationBuilder.DropIndex(
                name: "IX_newvacationrequest_DestinationRequestNamename",
                table: "newvacationrequest");

            migrationBuilder.DropColumn(
                name: "DestinationRequestNamename",
                table: "newvacationrequest");

            migrationBuilder.DropColumn(
                name: "VacationDetailsName",
                table: "newvacationrequest");
        }
    }
}
