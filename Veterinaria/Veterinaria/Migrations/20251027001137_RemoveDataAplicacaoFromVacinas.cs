using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDataAplicacaoFromVacinas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinas_Animais_AnimalId",
                table: "Vacinas");

            migrationBuilder.DropIndex(
                name: "IX_Vacinas_AnimalId",
                table: "Vacinas");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Vacinas");

            migrationBuilder.DropColumn(
                name: "DataAplicacao",
                table: "Vacinas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Vacinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAplicacao",
                table: "Vacinas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas_AnimalId",
                table: "Vacinas",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinas_Animais_AnimalId",
                table: "Vacinas",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
