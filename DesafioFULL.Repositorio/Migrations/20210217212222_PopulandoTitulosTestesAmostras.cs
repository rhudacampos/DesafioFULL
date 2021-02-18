using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFULL.Repositorio.Migrations
{
    public partial class PopulandoTitulosTestesAmostras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CPF", "Fone", "Nome", "SobreNome" },
                values: new object[] { 1L, "06734084000", "14999999999", "Fulano", "Beltrano" });

            migrationBuilder.InsertData(
                table: "Titulos",
                columns: new[] { "Id", "ClienteId", "DiasEmAtraso", "PerJuros", "PerMulta", "QtdeParcelas", "VlrCorrigido", "VlrJuros", "VlrMulta", "VlrOriginal" },
                values: new object[] { 1L, 1L, 0, 1m, 2m, 0, 0m, 0m, 0m, 300m });

            migrationBuilder.InsertData(
                table: "TituloParcelas",
                columns: new[] { "Id", "NumParcela", "TituloId", "Vencimento", "VlrCorrigido", "VlrJuros", "VlrMulta", "VlrOriginal" },
                values: new object[] { 1L, 1, 1L, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 100m });

            migrationBuilder.InsertData(
                table: "TituloParcelas",
                columns: new[] { "Id", "NumParcela", "TituloId", "Vencimento", "VlrCorrigido", "VlrJuros", "VlrMulta", "VlrOriginal" },
                values: new object[] { 2L, 2, 1L, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 100m });

            migrationBuilder.InsertData(
                table: "TituloParcelas",
                columns: new[] { "Id", "NumParcela", "TituloId", "Vencimento", "VlrCorrigido", "VlrJuros", "VlrMulta", "VlrOriginal" },
                values: new object[] { 3L, 3, 1L, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 100m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TituloParcelas",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TituloParcelas",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TituloParcelas",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Titulos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
