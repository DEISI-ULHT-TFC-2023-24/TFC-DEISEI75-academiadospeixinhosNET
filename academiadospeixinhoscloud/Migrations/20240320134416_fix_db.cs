using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace academiadospeixinhoscloud.Migrations
{
    /// <inheritdoc />
    public partial class fix_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Valida = table.Column<bool>(type: "bit", nullable: false),
                    Professor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auxiliar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crianca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroUtente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeguroSaude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apolice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seguradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoradaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeAgregado = table.Column<int>(type: "int", nullable: true),
                    Autorizados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doencas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NBI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidadeBI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomesAtividades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomesPais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomesSubscricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomesProduto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crianca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ementa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomesSalas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ementa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Professor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    NomesSalas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroUtente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoradaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NBI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidadeBI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomesCriancas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Valida = table.Column<bool>(type: "bit", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomesCriancas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomesSalas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscricao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeCrianca",
                columns: table => new
                {
                    AtividadesId = table.Column<int>(type: "int", nullable: false),
                    CriancasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeCrianca", x => new { x.AtividadesId, x.CriancasId });
                    table.ForeignKey(
                        name: "FK_AtividadeCrianca_Atividade_AtividadesId",
                        column: x => x.AtividadesId,
                        principalTable: "Atividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeCrianca_Crianca_CriancasId",
                        column: x => x.CriancasId,
                        principalTable: "Crianca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriancaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Crianca_CriancaId",
                        column: x => x.CriancaId,
                        principalTable: "Crianca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VagasPreenchidas = table.Column<int>(type: "int", nullable: false),
                    VagasTotal = table.Column<int>(type: "int", nullable: false),
                    Educadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auxiliar1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auxiliar2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auxiliar3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomesSubscricoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmentaId = table.Column<int>(type: "int", nullable: true),
                    EventoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Ementa_EmentaId",
                        column: x => x.EmentaId,
                        principalTable: "Ementa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sala_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CriancaPai",
                columns: table => new
                {
                    CriancasId = table.Column<int>(type: "int", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriancaPai", x => new { x.CriancasId, x.PaisId });
                    table.ForeignKey(
                        name: "FK_CriancaPai_Crianca_CriancasId",
                        column: x => x.CriancasId,
                        principalTable: "Crianca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriancaPai_Pai_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriancaSubscricao",
                columns: table => new
                {
                    CriancasId = table.Column<int>(type: "int", nullable: false),
                    SubscricaoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriancaSubscricao", x => new { x.CriancasId, x.SubscricaoesId });
                    table.ForeignKey(
                        name: "FK_CriancaSubscricao_Crianca_CriancasId",
                        column: x => x.CriancasId,
                        principalTable: "Crianca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriancaSubscricao_Subscricao_SubscricaoesId",
                        column: x => x.SubscricaoesId,
                        principalTable: "Subscricao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaSubscricao",
                columns: table => new
                {
                    SalasId = table.Column<int>(type: "int", nullable: false),
                    SubscricoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaSubscricao", x => new { x.SalasId, x.SubscricoesId });
                    table.ForeignKey(
                        name: "FK_SalaSubscricao_Sala_SalasId",
                        column: x => x.SalasId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaSubscricao_Subscricao_SubscricoesId",
                        column: x => x.SubscricoesId,
                        principalTable: "Subscricao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeCrianca_CriancasId",
                table: "AtividadeCrianca",
                column: "CriancasId");

            migrationBuilder.CreateIndex(
                name: "IX_CriancaPai_PaisId",
                table: "CriancaPai",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_CriancaSubscricao_SubscricaoesId",
                table: "CriancaSubscricao",
                column: "SubscricaoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CriancaId",
                table: "Produto",
                column: "CriancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_EmentaId",
                table: "Sala",
                column: "EmentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_EventoId",
                table: "Sala",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaSubscricao_SubscricoesId",
                table: "SalaSubscricao",
                column: "SubscricoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeCrianca");

            migrationBuilder.DropTable(
                name: "CriancaPai");

            migrationBuilder.DropTable(
                name: "CriancaSubscricao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "SalaSubscricao");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Pai");

            migrationBuilder.DropTable(
                name: "Crianca");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Subscricao");

            migrationBuilder.DropTable(
                name: "Ementa");

            migrationBuilder.DropTable(
                name: "Evento");
        }
    }
}
