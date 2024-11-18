using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NH_Sys_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfkproducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscalaId",
                table: "productos_tb",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "productos_tb",
                type: "integer",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_productos_tb_EscalaId",
                table: "productos_tb",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_tb_MarcaId",
                table: "productos_tb",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_tb_EscalaProductos_EscalaId",
                table: "productos_tb",
                column: "EscalaId",
                principalTable: "EscalaProductos",
                principalColumn: "IdEscala",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_tb_MarcaProductos_MarcaId",
                table: "productos_tb",
                column: "MarcaId",
                principalTable: "MarcaProductos",
                principalColumn: "IdMarca",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_tb_EscalaProductos_EscalaId",
                table: "productos_tb");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_tb_MarcaProductos_MarcaId",
                table: "productos_tb");

            migrationBuilder.DropIndex(
                name: "IX_productos_tb_EscalaId",
                table: "productos_tb");

            migrationBuilder.DropIndex(
                name: "IX_productos_tb_MarcaId",
                table: "productos_tb");

            migrationBuilder.RenameColumn(
                name: "MarcaId",
                table: "productos_tb",
                newName: "IdMarca");

            migrationBuilder.RenameColumn(
                name: "EscalaId",
                table: "productos_tb",
                newName: "IdEscala");



           
        }
    }
}
