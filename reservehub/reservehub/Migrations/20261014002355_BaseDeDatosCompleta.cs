using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservehub.Migrations
{
    /// <inheritdoc />
    public partial class BaseDeDatosCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmisorRol",
                table: "ChatMensajes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMensajes_UsuarioId",
                table: "ChatMensajes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMensajes_Usuarios_UsuarioId",
                table: "ChatMensajes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMensajes_Usuarios_UsuarioId",
                table: "ChatMensajes");

            migrationBuilder.DropIndex(
                name: "IX_ChatMensajes_UsuarioId",
                table: "ChatMensajes");

            migrationBuilder.AlterColumn<string>(
                name: "EmisorRol",
                table: "ChatMensajes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
