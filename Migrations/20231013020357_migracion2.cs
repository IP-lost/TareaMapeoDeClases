using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareaMapeoDeClases.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(

                name: "FK_DetalleUsuario_Usuario_UsuarioId",
                table: "DetalleUsuario");

            migrationBuilder.DropIndex(
                name: "IX_DetalleUsuario_UsuarioId",
                table: "DetalleUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "DetalleUsuario");

            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuario_Id",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DetalleUsuario_Id",
                table: "Usuario",
                column: "DetalleUsuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "Usuario",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuario",
                principalColumn: "Detalle_Usuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DetalleUsuario_Id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DetalleUsuario_Id",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "DetalleUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleUsuario_UsuarioId",
                table: "DetalleUsuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleUsuario_Usuario_UsuarioId",
                table: "DetalleUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
