using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Comanda.Api.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaCardapioId",
                table: "CardapioItens",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categoriaCardapios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaCardapios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CardapioItens",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriaCardapioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CardapioItens",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriaCardapioId",
                value: null);

            migrationBuilder.InsertData(
                table: "categoriaCardapios",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, null, "lanche" },
                    { 2, null, "Bebidas" },
                    { 3, null, "Acompanhamentos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardapioItens_CategoriaCardapioId",
                table: "CardapioItens",
                column: "CategoriaCardapioId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardapioItens_categoriaCardapios_CategoriaCardapioId",
                table: "CardapioItens",
                column: "CategoriaCardapioId",
                principalTable: "categoriaCardapios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardapioItens_categoriaCardapios_CategoriaCardapioId",
                table: "CardapioItens");

            migrationBuilder.DropTable(
                name: "categoriaCardapios");

            migrationBuilder.DropIndex(
                name: "IX_CardapioItens_CategoriaCardapioId",
                table: "CardapioItens");

            migrationBuilder.DropColumn(
                name: "CategoriaCardapioId",
                table: "CardapioItens");
        }
    }
}
