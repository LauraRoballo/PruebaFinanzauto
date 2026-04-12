using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaFinanzauto.Migrations
{
    /// <inheritdoc />
    public partial class DatoVIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_Placa",
                table: "Vehiculos");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Vehiculos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Placa",
                table: "Vehiculos",
                column: "Placa",
                unique: true,
                filter: "[Placa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_VIN",
                table: "Vehiculos",
                column: "VIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_Placa",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_VIN",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Vehiculos");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Placa",
                table: "Vehiculos",
                column: "Placa",
                unique: true);
        }
    }
}
