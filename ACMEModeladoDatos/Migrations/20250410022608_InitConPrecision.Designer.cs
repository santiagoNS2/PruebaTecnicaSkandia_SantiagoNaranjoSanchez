﻿// <auto-generated />
using System;
using ACMEModeladoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ACMEModeladoDatos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250410022608_InitConPrecision")]
    partial class InitConPrecision
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.CuentaAhorro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaldoCanje")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoDisponible")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CuentasAhorro");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.CuentaAhorroTitular", b =>
                {
                    b.Property<int>("CuentaAhorroId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("CuentaAhorroId", "PersonaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("CuentasTitulares");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.MovimientoCuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CuentaAhorroId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaTransaccion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CuentaAhorroId");

                    b.ToTable("MovimientosCuenta");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.MovimientoTarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaTransaccion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TarjetaCreditoId")
                        .HasColumnType("int");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaCreditoId");

                    b.ToTable("MovimientosTarjeta");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartamentoResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipioResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.RolPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("RolesPersona");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.TarjetaCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CupoAprobado")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CupoDisponible")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Franquicia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("TarjetasCredito");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.CuentaAhorroTitular", b =>
                {
                    b.HasOne("ACMEModeladoDatos.Modelos.CuentaAhorro", "CuentaAhorro")
                        .WithMany("Titulares")
                        .HasForeignKey("CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACMEModeladoDatos.Modelos.Persona", "Persona")
                        .WithMany("Cuentas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaAhorro");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.MovimientoCuenta", b =>
                {
                    b.HasOne("ACMEModeladoDatos.Modelos.CuentaAhorro", "CuentaAhorro")
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaAhorroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaAhorro");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.MovimientoTarjeta", b =>
                {
                    b.HasOne("ACMEModeladoDatos.Modelos.TarjetaCredito", "TarjetaCredito")
                        .WithMany("Movimientos")
                        .HasForeignKey("TarjetaCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TarjetaCredito");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.RolPersona", b =>
                {
                    b.HasOne("ACMEModeladoDatos.Modelos.Persona", "Persona")
                        .WithMany("Roles")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.TarjetaCredito", b =>
                {
                    b.HasOne("ACMEModeladoDatos.Modelos.Persona", "Persona")
                        .WithMany("Tarjetas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.CuentaAhorro", b =>
                {
                    b.Navigation("Movimientos");

                    b.Navigation("Titulares");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.Persona", b =>
                {
                    b.Navigation("Cuentas");

                    b.Navigation("Roles");

                    b.Navigation("Tarjetas");
                });

            modelBuilder.Entity("ACMEModeladoDatos.Modelos.TarjetaCredito", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
