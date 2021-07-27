using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class cargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    EstadosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.EstadosID);
                });

            migrationBuilder.CreateTable(
                name: "estudiante",
                columns: table => new
                {
                    EstudianteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante", x => x.EstudianteID);
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    PeriodoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x.PeriodoID);
                });

            migrationBuilder.CreateTable(
                name: "tiposPago",
                columns: table => new
                {
                    TiposPagoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposPago", x => x.TiposPagoID);
                });

            migrationBuilder.CreateTable(
                name: "penalizacion",
                columns: table => new
                {
                    PenalizacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePenalizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penalizacion", x => x.PenalizacionID);
                    table.ForeignKey(
                        name: "FK_penalizacion_estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "estados",
                        principalColumn: "EstadosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagosPorPeriodo",
                columns: table => new
                {
                    PagosPorPeriodoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension5 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension6 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension7 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension8 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pension9 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatriculaMora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora5 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora6 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora7 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora8 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PensionMora9 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagosPorPeriodo", x => x.PagosPorPeriodoID);
                    table.ForeignKey(
                        name: "FK_pagosPorPeriodo_periodo_PeriodoID",
                        column: x => x.PeriodoID,
                        principalTable: "periodo",
                        principalColumn: "PeriodoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "configuracion",
                columns: table => new
                {
                    ConfiguracionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoID = table.Column<int>(type: "int", nullable: false),
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracion", x => x.ConfiguracionID);
                    table.ForeignKey(
                        name: "FK_configuracion_estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "estados",
                        principalColumn: "EstadosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_configuracion_tiposPago_TipoID",
                        column: x => x.TipoID,
                        principalTable: "tiposPago",
                        principalColumn: "TiposPagoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    PagosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPago = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<bool>(type: "bit", nullable: false),
                    Mora = table.Column<bool>(type: "bit", nullable: false),
                    TotalAPagar = table.Column<float>(type: "real", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodoID = table.Column<int>(type: "int", nullable: false),
                    EstudianteID = table.Column<int>(type: "int", nullable: false),
                    TiposPagoID = table.Column<int>(type: "int", nullable: false),
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.PagosID);
                    table.ForeignKey(
                        name: "FK_pagos_estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "estados",
                        principalColumn: "EstadosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pagos_estudiante_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "estudiante",
                        principalColumn: "EstudianteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pagos_periodo_PeriodoID",
                        column: x => x.PeriodoID,
                        principalTable: "periodo",
                        principalColumn: "PeriodoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pagos_tiposPago_TiposPagoID",
                        column: x => x.TiposPagoID,
                        principalTable: "tiposPago",
                        principalColumn: "TiposPagoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_configuracion_EstadoID",
                table: "configuracion",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_configuracion_TipoID",
                table: "configuracion",
                column: "TipoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pagos_EstadoID",
                table: "pagos",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_EstudianteID",
                table: "pagos",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_PeriodoID",
                table: "pagos",
                column: "PeriodoID");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_TiposPagoID",
                table: "pagos",
                column: "TiposPagoID");

            migrationBuilder.CreateIndex(
                name: "IX_pagosPorPeriodo_PeriodoID",
                table: "pagosPorPeriodo",
                column: "PeriodoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_penalizacion_EstadoID",
                table: "penalizacion",
                column: "EstadoID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracion");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "pagosPorPeriodo");

            migrationBuilder.DropTable(
                name: "penalizacion");

            migrationBuilder.DropTable(
                name: "estudiante");

            migrationBuilder.DropTable(
                name: "tiposPago");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.DropTable(
                name: "estados");
        }
    }
}
