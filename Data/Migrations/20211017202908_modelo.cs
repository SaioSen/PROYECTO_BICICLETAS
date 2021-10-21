using Microsoft.EntityFrameworkCore.Migrations;

namespace PROYECTO_BICICLETAS.Data.Migrations
{
    public partial class modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "modelo",
                table: "t_producto",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modelo",
                table: "t_producto");
        }
    }
}
