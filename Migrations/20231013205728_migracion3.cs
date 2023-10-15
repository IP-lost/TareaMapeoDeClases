using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareaMapeoDeClases.Migrations
{
    public partial class migracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoria_Id",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    Articulo_Id = table.Column<int>(type: "int", nullable: false),
                    Etiqueta_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.Etiqueta_Id, x.Articulo_Id });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Articulo_Articulo_Id",
                        column: x => x.Articulo_Id,
                        principalTable: "Articulo",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id",
                        column: x => x.Etiqueta_Id,
                        principalTable: "Etiqueta",
                        principalColumn: "Etiqueta_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_Categoria_Id",
                table: "Articulo",
                column: "Categoria_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Categoria_Categoria_Id",
                table: "Articulo",
                column: "Categoria_Id",
                principalTable: "Categoria",
                principalColumn: "Categoria_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Categoria_Categoria_Id",
                table: "Articulo");

            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_Categoria_Id",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Categoria_Id",
                table: "Articulo");
        }
    }
}
