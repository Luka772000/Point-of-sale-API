using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace POS_Backend.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StavkeRacuna",
                table: "StavkeRacuna");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StavkeRacuna",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StavkeRacuna",
                table: "StavkeRacuna",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRacuna_ProizvodId",
                table: "StavkeRacuna",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StavkeRacuna",
                table: "StavkeRacuna");

            migrationBuilder.DropIndex(
                name: "IX_StavkeRacuna_ProizvodId",
                table: "StavkeRacuna");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StavkeRacuna",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StavkeRacuna",
                table: "StavkeRacuna",
                columns: new[] { "ProizvodId", "ZaglavljeRacunaId" });
        }
    }
}
