using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaFinanzauto.Migrations
{
    /// <inheritdoc />
    public partial class EstadoVendedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cedula",
                table: "Vendedores",
                newName: "Cedula");

            migrationBuilder.AlterColumn<string>(
                name: "MotivoEstado",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Vendedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "Vendedores",
                newName: "cedula");

            migrationBuilder.AlterColumn<string>(
                name: "MotivoEstado",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
