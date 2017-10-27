using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HmrcDotNet.Web.Data.Migrations
{
    public partial class CreateIndividual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Individuals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HmrcUserId",
                table: "Individuals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MtdItId",
                table: "Individuals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "HmrcUserId",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "MtdItId",
                table: "Individuals");
        }
    }
}
