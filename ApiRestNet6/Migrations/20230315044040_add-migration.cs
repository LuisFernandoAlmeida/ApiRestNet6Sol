using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestNet6.Migrations
{
    /// <inheritdoc />
    public partial class addmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "numeroVillas",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numeroVillas", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_numeroVillas_villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3694), new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3701), new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3700) });

            migrationBuilder.CreateIndex(
                name: "IX_numeroVillas_VillaId",
                table: "numeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "numeroVillas");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1698), new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1701), new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1701) });
        }
    }
}
