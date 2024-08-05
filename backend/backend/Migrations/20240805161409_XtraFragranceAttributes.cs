using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class XtraFragranceAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Fragrances",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LaunchDate",
                table: "Fragrances",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Fragrances",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "LaunchDate",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Fragrances");
        }
    }
}
