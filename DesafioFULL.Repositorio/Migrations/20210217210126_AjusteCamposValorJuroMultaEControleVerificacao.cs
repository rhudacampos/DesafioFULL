using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFULL.Repositorio.Migrations
{
    public partial class AjusteCamposValorJuroMultaEControleVerificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VlrJuros",
                table: "Titulos",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VlrMulta",
                table: "Titulos",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VlrJuros",
                table: "TituloParcelas",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VlrMulta",
                table: "TituloParcelas",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TituloVerificacoes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataVerificacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TituloVerificacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TituloVerificacoes");

            migrationBuilder.DropColumn(
                name: "VlrJuros",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "VlrMulta",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "VlrJuros",
                table: "TituloParcelas");

            migrationBuilder.DropColumn(
                name: "VlrMulta",
                table: "TituloParcelas");
        }
    }
}
