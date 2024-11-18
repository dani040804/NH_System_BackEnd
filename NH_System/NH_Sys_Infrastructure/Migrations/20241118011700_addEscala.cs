using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NH_Sys_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEscala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "productos_tb",
                newName: "MarcaNombre");

            migrationBuilder.RenameColumn(
                name: "Escala",
                table: "productos_tb",
                newName: "EscalaNombre");

            migrationBuilder.AddColumn<int>(
                name: "EscalaIdEscala",
                table: "productos_tb",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEscala",
                table: "productos_tb",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "productos_tb",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarcaIdMarca",
                table: "productos_tb",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EscalaProductos",
                columns: table => new
                {
                    IdEscala = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreEscala = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaProductos", x => x.IdEscala);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_tb_EscalaIdEscala",
                table: "productos_tb",
                column: "EscalaIdEscala");

            migrationBuilder.CreateIndex(
                name: "IX_productos_tb_MarcaIdMarca",
                table: "productos_tb",
                column: "MarcaIdMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_tb_EscalaProductos_EscalaIdEscala",
                table: "productos_tb",
                column: "EscalaIdEscala",
                principalTable: "EscalaProductos",
                principalColumn: "IdEscala");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_tb_MarcaProductos_MarcaIdMarca",
                table: "productos_tb",
                column: "MarcaIdMarca",
                principalTable: "MarcaProductos",
                principalColumn: "IdMarca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_tb_EscalaProductos_EscalaIdEscala",
                table: "productos_tb");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_tb_MarcaProductos_MarcaIdMarca",
                table: "productos_tb");

            migrationBuilder.DropTable(
                name: "EscalaProductos");

            migrationBuilder.DropIndex(
                name: "IX_productos_tb_EscalaIdEscala",
                table: "productos_tb");

            migrationBuilder.DropIndex(
                name: "IX_productos_tb_MarcaIdMarca",
                table: "productos_tb");

            migrationBuilder.DropColumn(
                name: "EscalaIdEscala",
                table: "productos_tb");

            migrationBuilder.DropColumn(
                name: "IdEscala",
                table: "productos_tb");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "productos_tb");

            migrationBuilder.DropColumn(
                name: "MarcaIdMarca",
                table: "productos_tb");

            migrationBuilder.RenameColumn(
                name: "MarcaNombre",
                table: "productos_tb",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "EscalaNombre",
                table: "productos_tb",
                newName: "Escala");
        }
    }
}
