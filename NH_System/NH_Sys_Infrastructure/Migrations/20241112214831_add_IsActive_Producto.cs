using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NH_Sys_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_IsActive_Producto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "productos_tb",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "productos_tb");

        }
    }
}
