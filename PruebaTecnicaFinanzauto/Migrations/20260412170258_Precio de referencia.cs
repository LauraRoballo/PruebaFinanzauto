using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaFinanzauto.Migrations
{
    /// <inheritdoc />
    public partial class Preciodereferencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecioReferencia",
                table: "Vehiculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Nombre",
                table: "Marcas",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marcas_Nombre",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "PrecioReferencia",
                table: "Vehiculos");
        }
    }
}
