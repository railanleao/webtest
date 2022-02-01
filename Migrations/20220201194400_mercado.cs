using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webtest.Migrations
{
    public partial class mercado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    SobreNome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "ItenVenda",
                columns: table => new
                {
                    ItemVendaId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    NumVendaId = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItenVenda", x => x.ItemVendaId);
                    table.ForeignKey(
                        name: "FK_ItenVenda_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentações",
                columns: table => new
                {
                    MovimentaçõesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Descrição = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DataHora = table.Column<DateTime>(name: "Data/Hora", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentações", x => x.MovimentaçõesId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descrição = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Preços = table.Column<double>(type: "double precision", nullable: false),
                    Categorias = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    Movimentações = table.Column<int>(type: "integer", maxLength: 500, nullable: false),
                    ItenVendaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_Categorias",
                        column: x => x.Categorias,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_ItenVenda_ItenVendaId",
                        column: x => x.ItenVendaId,
                        principalTable: "ItenVenda",
                        principalColumn: "ItemVendaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_ItenVenda_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "ItenVenda",
                        principalColumn: "ItemVendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    NumVendaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataHora = table.Column<DateTime>(name: "Data/Hora", type: "timestamp with time zone", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.NumVendaId);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItenVenda_ClienteId",
                table: "ItenVenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentações_ProdutoId",
                table: "Movimentações",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Categorias",
                table: "Produtos",
                column: "Categorias");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ItenVendaId",
                table: "Produtos",
                column: "ItenVendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutoId",
                table: "Vendas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItenVenda_Vendas_ItemVendaId",
                table: "ItenVenda",
                column: "ItemVendaId",
                principalTable: "Vendas",
                principalColumn: "NumVendaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentações_Produtos_ProdutoId",
                table: "Movimentações",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Vendas_ProdutoId",
                table: "Produtos",
                column: "ProdutoId",
                principalTable: "Vendas",
                principalColumn: "NumVendaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutoId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Movimentações");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ItenVenda");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
