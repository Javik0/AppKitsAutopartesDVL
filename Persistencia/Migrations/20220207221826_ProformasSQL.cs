using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDB.Migrations
{
    public partial class ProformasSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoValor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "kits",
                columns: table => new
                {
                    KitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kits", x => x.KitId);
                });

            migrationBuilder.CreateTable(
                name: "partes",
                columns: table => new
                {
                    ParteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partes", x => x.ParteId);
                });

            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    KitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_quotes_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quotes_estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quotes_kits_KitId",
                        column: x => x.KitId,
                        principalTable: "kits",
                        principalColumn: "KitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "altPartes",
                columns: table => new
                {
                    ParteAlternaId = table.Column<int>(type: "int", nullable: false),
                    ParteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_altPartes", x => new { x.ParteId, x.ParteAlternaId });
                    table.ForeignKey(
                        name: "FK_altPartes_partes_ParteAlternaId",
                        column: x => x.ParteAlternaId,
                        principalTable: "partes",
                        principalColumn: "ParteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_altPartes_partes_ParteId",
                        column: x => x.ParteId,
                        principalTable: "partes",
                        principalColumn: "ParteId");
                });

            migrationBuilder.CreateTable(
                name: "kitParts",
                columns: table => new
                {
                    KitId = table.Column<int>(type: "int", nullable: false),
                    ParteId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitParts", x => new { x.KitId, x.ParteId });
                    table.ForeignKey(
                        name: "FK_kitParts_kits_KitId",
                        column: x => x.KitId,
                        principalTable: "kits",
                        principalColumn: "KitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitParts_partes_ParteId",
                        column: x => x.ParteId,
                        principalTable: "partes",
                        principalColumn: "ParteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quoteParts",
                columns: table => new
                {
                    QuotePartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<bool>(type: "bit", nullable: false),
                    AltParteStock = table.Column<bool>(type: "bit", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    ParteId = table.Column<int>(type: "int", nullable: false),
                    AltParteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quoteParts", x => x.QuotePartId);
                    table.ForeignKey(
                        name: "FK_quoteParts_partes_AltParteId",
                        column: x => x.AltParteId,
                        principalTable: "partes",
                        principalColumn: "ParteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quoteParts_partes_ParteId",
                        column: x => x.ParteId,
                        principalTable: "partes",
                        principalColumn: "ParteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quoteParts_quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_altPartes_ParteAlternaId",
                table: "altPartes",
                column: "ParteAlternaId");

            migrationBuilder.CreateIndex(
                name: "IX_kitParts_ParteId",
                table: "kitParts",
                column: "ParteId");

            migrationBuilder.CreateIndex(
                name: "IX_quoteParts_AltParteId",
                table: "quoteParts",
                column: "AltParteId");

            migrationBuilder.CreateIndex(
                name: "IX_quoteParts_ParteId",
                table: "quoteParts",
                column: "ParteId");

            migrationBuilder.CreateIndex(
                name: "IX_quoteParts_QuoteId",
                table: "quoteParts",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_ClienteId",
                table: "quotes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_EstadoId",
                table: "quotes",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_KitId",
                table: "quotes",
                column: "KitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "altPartes");

            migrationBuilder.DropTable(
                name: "kitParts");

            migrationBuilder.DropTable(
                name: "quoteParts");

            migrationBuilder.DropTable(
                name: "partes");

            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "kits");
        }
    }
}
