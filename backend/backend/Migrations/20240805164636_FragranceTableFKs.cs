using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FragranceTableFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LongevityId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScentId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SillageId",
                table: "Fragrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_BrandId",
                table: "Fragrances",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_CategoryId",
                table: "Fragrances",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_GenderId",
                table: "Fragrances",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_LongevityId",
                table: "Fragrances",
                column: "LongevityId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_ScentId",
                table: "Fragrances",
                column: "ScentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_SeasonId",
                table: "Fragrances",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragrances_SillageId",
                table: "Fragrances",
                column: "SillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Brands_BrandId",
                table: "Fragrances",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Categories_CategoryId",
                table: "Fragrances",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Genders_GenderId",
                table: "Fragrances",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Longevities_LongevityId",
                table: "Fragrances",
                column: "LongevityId",
                principalTable: "Longevities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Scents_ScentId",
                table: "Fragrances",
                column: "ScentId",
                principalTable: "Scents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Seasons_SeasonId",
                table: "Fragrances",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragrances_Sillages_SillageId",
                table: "Fragrances",
                column: "SillageId",
                principalTable: "Sillages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Brands_BrandId",
                table: "Fragrances");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Categories_CategoryId",
                table: "Fragrances");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Genders_GenderId",
                table: "Fragrances");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Longevities_LongevityId",
                table: "Fragrances");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Scents_ScentId",
                table: "Fragrances");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Seasons_SeasonId",
                table: "Fragrances");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragrances_Sillages_SillageId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_BrandId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_CategoryId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_GenderId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_LongevityId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_ScentId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_SeasonId",
                table: "Fragrances");

            migrationBuilder.DropIndex(
                name: "IX_Fragrances_SillageId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "LongevityId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "ScentId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Fragrances");

            migrationBuilder.DropColumn(
                name: "SillageId",
                table: "Fragrances");
        }
    }
}
