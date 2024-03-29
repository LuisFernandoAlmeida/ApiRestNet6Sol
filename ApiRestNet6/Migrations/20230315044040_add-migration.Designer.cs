﻿// <auto-generated />
using System;
using ApiRestNet6.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRestNet6.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230315044040_add-migration")]
    partial class addmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiRestNet6.Modelos.NumeroVilla", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Actualizacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetalleEspecial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("numeroVillas");
                });

            modelBuilder.Entity("ApiRestNet6.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<int>("Tarifa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalla de la Villa",
                            FechaActualizacion = new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3694),
                            FechaCreacion = new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3693),
                            ImagenUrl = "",
                            MetrosCuadrados = 50,
                            Nombre = "Villa 1",
                            Ocupantes = 5,
                            Tarifa = 200
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Villa vista a la Piscina",
                            FechaActualizacion = new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3701),
                            FechaCreacion = new DateTime(2023, 3, 14, 23, 40, 40, 493, DateTimeKind.Local).AddTicks(3700),
                            ImagenUrl = "",
                            MetrosCuadrados = 50,
                            Nombre = "Villa 2",
                            Ocupantes = 5,
                            Tarifa = 200
                        });
                });

            modelBuilder.Entity("ApiRestNet6.Modelos.NumeroVilla", b =>
                {
                    b.HasOne("ApiRestNet6.Modelos.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
