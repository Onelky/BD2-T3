using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ejemplo.Migrations
{
    public partial class Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanes",
                columns: table => new
                {
                    TipoPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanes", x => x.TipoPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Correo = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
                    Telefono = table.Column<string>(type: "CHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Personas_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_Regiones_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaRol",
                columns: table => new
                {
                    PersonasPersonaId = table.Column<int>(type: "int", nullable: false),
                    RolesRolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRol", x => new { x.PersonasPersonaId, x.RolesRolId });
                    table.ForeignKey(
                        name: "FK_PersonaRol_Personas_PersonasPersonaId",
                        column: x => x.PersonasPersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaRol_Roles_RolesRolId",
                        column: x => x.RolesRolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaId);
                    table.ForeignKey(
                        name: "FK_Provincias_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hoteles_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edificios",
                columns: table => new
                {
                    EdificioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificios", x => x.EdificioId);
                    table.ForeignKey(
                        name: "FK_Edificios_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    ReservacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReservacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantAdultos = table.Column<int>(type: "int", nullable: false),
                    CantNiños = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<float>(type: "real", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    TipoPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionId);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservaciones_TipoPlanes_TipoPlanId",
                        column: x => x.TipoPlanId,
                        principalTable: "TipoPlanes",
                        principalColumn: "TipoPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<decimal>(type: "money", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReservacionId = table.Column<int>(type: "int", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edificios_HotelId",
                table: "Edificios",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_ProvinciaId",
                table: "Hoteles",
                column: "ProvinciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ReservacionId",
                table: "Pagos",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRol_RolesRolId",
                table: "PersonaRol",
                column: "RolesRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PaisId",
                table: "Personas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_RegionId",
                table: "Provincias",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_PaisId",
                table: "Regiones",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_HotelId",
                table: "Reservaciones",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_PersonaId",
                table: "Reservaciones",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_TipoPlanId",
                table: "Reservaciones",
                column: "TipoPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edificios");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PersonaRol");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Hoteles");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TipoPlanes");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
