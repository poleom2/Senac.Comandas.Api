using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Comanda.Api.Migrations
{
    /// <inheritdoc />
    public partial class cadastro_mesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardapioItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    PossuiPreparo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardapioItens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroMesa = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeCliente = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroMesa = table.Column<int>(type: "INTEGER", nullable: false),
                    SituacaoMesa = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroMesa = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComandaItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComandaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CardapioItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComandaItens_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosCozinhas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComandaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosCozinhas", x => x.id);
                    table.ForeignKey(
                        name: "FK_PedidosCozinhas_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosCozinhaItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PedidoCozinhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ComandaItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosCozinhaItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosCozinhaItens_ComandaItens_ComandaItemId",
                        column: x => x.ComandaItemId,
                        principalTable: "ComandaItens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosCozinhaItens_PedidosCozinhas_PedidoCozinhaId",
                        column: x => x.PedidoCozinhaId,
                        principalTable: "PedidosCozinhas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CardapioItens",
                columns: new[] { "Id", "Descricao", "Imagem", "PossuiPreparo", "Preco", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { 1, " 2 Carne, Queijo, Tomate, Cebola dulce, Molho da casa", "https://img77.uenicdn.com/image/upload/v1543484687/service_images/shutterstock_1040760661.jpg", true, 30m, "Lanche", " X Carne" },
                    { 2, " 2 Carne, Queijo, Tomate, Cebola dulce, Molho da casa", "https://img77.uenicdn.com/image/upload/v1543484687/service_images/shutterstock_1040760661.jpg", true, 30m, "Lanche", " X Carne" }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "NumeroMesa", "SituacaoMesa" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[] { 1, "adm", "adm", "adm1234" });

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItens_ComandaId",
                table: "ComandaItens",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosCozinhaItens_ComandaItemId",
                table: "PedidosCozinhaItens",
                column: "ComandaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosCozinhaItens_PedidoCozinhaId",
                table: "PedidosCozinhaItens",
                column: "PedidoCozinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosCozinhas_ComandaId",
                table: "PedidosCozinhas",
                column: "ComandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardapioItens");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "PedidosCozinhaItens");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ComandaItens");

            migrationBuilder.DropTable(
                name: "PedidosCozinhas");

            migrationBuilder.DropTable(
                name: "Comandas");
        }
    }
}
