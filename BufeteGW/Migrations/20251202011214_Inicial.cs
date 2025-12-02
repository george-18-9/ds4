using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BufeteGW.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GW_Abogados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GW_Abogados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GW_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GW_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GW_Casos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbogadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GW_Casos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GW_Casos_GW_Abogados_AbogadoId",
                        column: x => x.AbogadoId,
                        principalTable: "GW_Abogados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GW_Casos_GW_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "GW_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GW_Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GW_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GW_Documentos_GW_Casos_CasoId",
                        column: x => x.CasoId,
                        principalTable: "GW_Casos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GW_Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CasoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GW_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GW_Eventos_GW_Casos_CasoId",
                        column: x => x.CasoId,
                        principalTable: "GW_Casos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GW_Casos_AbogadoId",
                table: "GW_Casos",
                column: "AbogadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GW_Casos_ClienteId",
                table: "GW_Casos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_GW_Documentos_CasoId",
                table: "GW_Documentos",
                column: "CasoId");

            migrationBuilder.CreateIndex(
                name: "IX_GW_Eventos_CasoId",
                table: "GW_Eventos",
                column: "CasoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GW_Documentos");

            migrationBuilder.DropTable(
                name: "GW_Eventos");

            migrationBuilder.DropTable(
                name: "GW_Casos");

            migrationBuilder.DropTable(
                name: "GW_Abogados");

            migrationBuilder.DropTable(
                name: "GW_Clientes");
        }
    }
}
