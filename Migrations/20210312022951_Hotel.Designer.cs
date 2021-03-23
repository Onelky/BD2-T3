﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ejemplo.Models;

namespace ejemplo.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20210312022951_Hotel")]
    partial class Hotel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonaRol", b =>
                {
                    b.Property<int>("PersonasPersonaId")
                        .HasColumnType("int");

                    b.Property<int>("RolesRolId")
                        .HasColumnType("int");

                    b.HasKey("PersonasPersonaId", "RolesRolId");

                    b.HasIndex("RolesRolId");

                    b.ToTable("PersonaRol");
                });

            modelBuilder.Entity("ejemplo.Models.Edificio", b =>
                {
                    b.Property<int>("EdificioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EdificioId");

                    b.HasIndex("HotelId");

                    b.ToTable("Edificios");
                });

            modelBuilder.Entity("ejemplo.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.HasIndex("ProvinciaId")
                        .IsUnique();

                    b.ToTable("Hoteles");
                });

            modelBuilder.Entity("ejemplo.Models.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("money");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("ReservacionId")
                        .HasColumnType("int");

                    b.Property<string>("TipoPago")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PagoId");

                    b.HasIndex("ReservacionId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("ejemplo.Models.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("ejemplo.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("VARCHAR(25)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("VARCHAR(25)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("CHAR(10)");

                    b.HasKey("PersonaId");

                    b.HasIndex("PaisId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ejemplo.Models.Provincia", b =>
                {
                    b.Property<int>("ProvinciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("ProvinciaId");

                    b.HasIndex("RegionId");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("ejemplo.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("RegionId");

                    b.HasIndex("PaisId");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("ejemplo.Models.Reservacion", b =>
                {
                    b.Property<int>("ReservacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantAdultos")
                        .HasColumnType("int");

                    b.Property<int>("CantNiños")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<float>("CostoTotal")
                        .HasColumnType("real");

                    b.Property<DateTime>("FechaReservacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPlanId")
                        .HasColumnType("int");

                    b.HasKey("ReservacionId");

                    b.HasIndex("HotelId");

                    b.HasIndex("PersonaId");

                    b.HasIndex("TipoPlanId");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("ejemplo.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ejemplo.Models.TipoPlan", b =>
                {
                    b.Property<int>("TipoPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("TipoPlanId");

                    b.ToTable("TipoPlanes");
                });

            modelBuilder.Entity("PersonaRol", b =>
                {
                    b.HasOne("ejemplo.Models.Persona", null)
                        .WithMany()
                        .HasForeignKey("PersonasPersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ejemplo.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ejemplo.Models.Edificio", b =>
                {
                    b.HasOne("ejemplo.Models.Hotel", "Hotel")
                        .WithMany("Edificios")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("ejemplo.Models.Hotel", b =>
                {
                    b.HasOne("ejemplo.Models.Provincia", "Provincia")
                        .WithOne("Hotel")
                        .HasForeignKey("ejemplo.Models.Hotel", "ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("ejemplo.Models.Pago", b =>
                {
                    b.HasOne("ejemplo.Models.Reservacion", "Reservacion")
                        .WithMany("Pagos")
                        .HasForeignKey("ReservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservacion");
                });

            modelBuilder.Entity("ejemplo.Models.Persona", b =>
                {
                    b.HasOne("ejemplo.Models.Pais", "Pais")
                        .WithMany("Personas")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ejemplo.Models.Provincia", b =>
                {
                    b.HasOne("ejemplo.Models.Region", "Region")
                        .WithMany("Provincias")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ejemplo.Models.Region", b =>
                {
                    b.HasOne("ejemplo.Models.Pais", "Pais")
                        .WithMany("Regiones")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ejemplo.Models.Reservacion", b =>
                {
                    b.HasOne("ejemplo.Models.Hotel", "Hotel")
                        .WithMany("Reservaciones")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ejemplo.Models.Persona", "Persona")
                        .WithMany("Reservaciones")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ejemplo.Models.TipoPlan", "TipoPlan")
                        .WithMany("Reservaciones")
                        .HasForeignKey("TipoPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Persona");

                    b.Navigation("TipoPlan");
                });

            modelBuilder.Entity("ejemplo.Models.Hotel", b =>
                {
                    b.Navigation("Edificios");

                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("ejemplo.Models.Pais", b =>
                {
                    b.Navigation("Personas");

                    b.Navigation("Regiones");
                });

            modelBuilder.Entity("ejemplo.Models.Persona", b =>
                {
                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("ejemplo.Models.Provincia", b =>
                {
                    b.Navigation("Hotel")
                        .IsRequired();
                });

            modelBuilder.Entity("ejemplo.Models.Region", b =>
                {
                    b.Navigation("Provincias");
                });

            modelBuilder.Entity("ejemplo.Models.Reservacion", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("ejemplo.Models.TipoPlan", b =>
                {
                    b.Navigation("Reservaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
