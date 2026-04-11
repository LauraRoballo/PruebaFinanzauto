using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaFinanzauto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEstadoVendedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotivoEstado",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "MotivoEstado",
                table: "Vendedores");
        }
    }
}
