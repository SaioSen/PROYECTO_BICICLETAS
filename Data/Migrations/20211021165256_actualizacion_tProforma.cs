using Microsoft.EntityFrameworkCore.Migrations;

namespace PROYECTO_BICICLETAS.Data.Migrations
{
    public partial class actualizacion_tProforma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "t_proforma",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "t_proforma");
        }
    }
}
