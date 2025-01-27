using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.Migrations
{
    /// <inheritdoc />
    public partial class powerheromany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroEntityPowerEntity_Heros_HeroesId",
                table: "HeroEntityPowerEntity");

            migrationBuilder.RenameColumn(
                name: "HeroesId",
                table: "HeroEntityPowerEntity",
                newName: "HeroEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroEntityPowerEntity_Heros_HeroEntityId",
                table: "HeroEntityPowerEntity",
                column: "HeroEntityId",
                principalTable: "Heros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroEntityPowerEntity_Heros_HeroEntityId",
                table: "HeroEntityPowerEntity");

            migrationBuilder.RenameColumn(
                name: "HeroEntityId",
                table: "HeroEntityPowerEntity",
                newName: "HeroesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroEntityPowerEntity_Heros_HeroesId",
                table: "HeroEntityPowerEntity",
                column: "HeroesId",
                principalTable: "Heros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
