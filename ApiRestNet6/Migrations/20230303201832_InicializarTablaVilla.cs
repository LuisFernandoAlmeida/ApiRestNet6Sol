using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiRestNet6.Migrations
{
    /// <inheritdoc />
    public partial class InicializarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "villas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalla de la Villa", new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1698), new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1697), "", 50, "Villa 1", 5, 200 },
                    { 2, "", "Villa vista a la Piscina", new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1701), new DateTime(2023, 3, 3, 15, 18, 31, 766, DateTimeKind.Local).AddTicks(1701), "", 50, "Villa 2", 5, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "villas");
        }
    }
}
