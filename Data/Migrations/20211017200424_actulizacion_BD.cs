using Microsoft.EntityFrameworkCore.Migrations;

namespace PROYECTO_BICICLETAS.Data.Migrations
{
    public partial class actulizacion_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "categoria",
                table: "t_producto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "t_producto",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "t_producto");

            migrationBuilder.AlterColumn<string>(
                name: "categoria",
                table: "t_producto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
