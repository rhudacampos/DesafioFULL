using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFULL.Repositorio.Migrations
{
    public partial class UsuarioAdministrador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Senha", "SobreNome" },
                values: new object[] { 1L, "admin@admin.com", "Administrador", "admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
