using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PIM.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rua = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    estado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    pais = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    cpf = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    senha = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    enderecoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_clientes_enderecos_enderecoId",
                        column: x => x.enderecoId,
                        principalTable: "enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    razaoSocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nomeFantasia = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    email = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    senha = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    comissao = table.Column<decimal>(type: "numeric", nullable: false),
                    enderecoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedores", x => x.id);
                    table.ForeignKey(
                        name: "FK_vendedores_enderecos_enderecoId",
                        column: x => x.enderecoId,
                        principalTable: "enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carrinhos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    statusPedido = table.Column<int>(type: "integer", nullable: false),
                    clienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrinhos", x => x.id);
                    table.ForeignKey(
                        name: "FK_carrinhos_clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    preco = table.Column<decimal>(type: "numeric", nullable: false),
                    imagem = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    vendedorId = table.Column<int>(type: "integer", nullable: false),
                    categoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produtos_vendedores_vendedorId",
                        column: x => x.vendedorId,
                        principalTable: "vendedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itensCarrinhos",
                columns: table => new
                {
                    carrinhoId = table.Column<int>(type: "integer", nullable: false),
                    produtoId = table.Column<int>(type: "integer", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itensCarrinhos", x => new { x.carrinhoId, x.produtoId });
                    table.ForeignKey(
                        name: "FK_itensCarrinhos_carrinhos_carrinhoId",
                        column: x => x.carrinhoId,
                        principalTable: "carrinhos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itensCarrinhos_produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carrinhos_clienteId",
                table: "carrinhos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_enderecoId",
                table: "clientes",
                column: "enderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_itensCarrinhos_produtoId",
                table: "itensCarrinhos",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_categoriaId",
                table: "produtos",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_vendedorId",
                table: "produtos",
                column: "vendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedores_enderecoId",
                table: "vendedores",
                column: "enderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itensCarrinhos");

            migrationBuilder.DropTable(
                name: "carrinhos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "vendedores");

            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
