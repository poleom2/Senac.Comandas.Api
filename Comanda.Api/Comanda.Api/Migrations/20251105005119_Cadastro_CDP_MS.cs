using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comanda.Api.Migrations
{
    /// <inheritdoc />
    public partial class Cadastro_CDP_MS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CardapioItens",
                columns: new[] { "Id", "Descricao", "Imagem", "PossuiPreparo", "Preco", "Tipo", "Titulo" },
                values: new object[] { 6, " 2 Carne, Queijo, Tomate, Cebola dulce, Molho da casa", "https://img77.uenicdn.com/image/upload/v1543484687/service_images/shutterstock_1040760661.jpg", true, 30m, "Lanche", " X Carne" });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "NumeroMesa", "SituacaoMesa" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardapioItens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
