﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20210727012720_cargaInicial")]
    partial class cargaInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.Pagos.Configuracion", b =>
                {
                    b.Property<int>("ConfiguracionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoID")
                        .HasColumnType("int");

                    b.Property<int>("TipoID")
                        .HasColumnType("int");

                    b.HasKey("ConfiguracionID");

                    b.HasIndex("EstadoID");

                    b.HasIndex("TipoID")
                        .IsUnique();

                    b.ToTable("configuracion");
                });

            modelBuilder.Entity("Modelo.Pagos.Estados", b =>
                {
                    b.Property<int>("EstadosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEstado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadosID");

                    b.ToTable("estados");
                });

            modelBuilder.Entity("Modelo.Pagos.Estudiante", b =>
                {
                    b.Property<int>("EstudianteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstudianteID");

                    b.ToTable("estudiante");
                });

            modelBuilder.Entity("Modelo.Pagos.Pagos", b =>
                {
                    b.Property<int>("PagosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Descuento")
                        .HasColumnType("bit");

                    b.Property<int>("EstadoID")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<string>("MetodoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Mora")
                        .HasColumnType("bit");

                    b.Property<int>("PeriodoID")
                        .HasColumnType("int");

                    b.Property<int>("TiposPagoID")
                        .HasColumnType("int");

                    b.Property<float>("TotalAPagar")
                        .HasColumnType("real");

                    b.Property<float>("ValorPago")
                        .HasColumnType("real");

                    b.HasKey("PagosID");

                    b.HasIndex("EstadoID");

                    b.HasIndex("EstudianteID");

                    b.HasIndex("PeriodoID");

                    b.HasIndex("TiposPagoID");

                    b.ToTable("pagos");
                });

            modelBuilder.Entity("Modelo.Pagos.PagosPorPeriodo", b =>
                {
                    b.Property<int>("PagosPorPeriodoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Matricula")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MatriculaMora")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension4")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension5")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension6")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension7")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension8")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pension9")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora4")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora5")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora6")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora7")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora8")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PensionMora9")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeriodoID")
                        .HasColumnType("int");

                    b.HasKey("PagosPorPeriodoID");

                    b.HasIndex("PeriodoID")
                        .IsUnique();

                    b.ToTable("pagosPorPeriodo");
                });

            modelBuilder.Entity("Modelo.Pagos.Penalizacion", b =>
                {
                    b.Property<int>("PenalizacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoID")
                        .HasColumnType("int");

                    b.Property<string>("NombrePenalizacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PenalizacionID");

                    b.HasIndex("EstadoID")
                        .IsUnique();

                    b.ToTable("penalizacion");
                });

            modelBuilder.Entity("Modelo.Pagos.Periodo", b =>
                {
                    b.Property<int>("PeriodoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("PeriodoAcademico")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeriodoID");

                    b.ToTable("periodo");
                });

            modelBuilder.Entity("Modelo.Pagos.TiposPago", b =>
                {
                    b.Property<int>("TiposPagoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<string>("NombreTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("TiposPagoID");

                    b.ToTable("tiposPago");
                });

            modelBuilder.Entity("Modelo.Pagos.Configuracion", b =>
                {
                    b.HasOne("Modelo.Pagos.Estados", "Estados")
                        .WithMany("configuraciones")
                        .HasForeignKey("EstadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Pagos.TiposPago", "TiposPago")
                        .WithOne("Configuracion")
                        .HasForeignKey("Modelo.Pagos.Configuracion", "TipoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("TiposPago");
                });

            modelBuilder.Entity("Modelo.Pagos.Pagos", b =>
                {
                    b.HasOne("Modelo.Pagos.Estados", "Estados")
                        .WithMany("pagos")
                        .HasForeignKey("EstadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Pagos.Estudiante", "Estudiante")
                        .WithMany("Pagos")
                        .HasForeignKey("EstudianteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Pagos.Periodo", "Periodo")
                        .WithMany("Pagos")
                        .HasForeignKey("PeriodoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Pagos.TiposPago", "TiposPago")
                        .WithMany("Pagos")
                        .HasForeignKey("TiposPagoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("Estudiante");

                    b.Navigation("Periodo");

                    b.Navigation("TiposPago");
                });

            modelBuilder.Entity("Modelo.Pagos.PagosPorPeriodo", b =>
                {
                    b.HasOne("Modelo.Pagos.Periodo", "Periodo")
                        .WithOne("pagosPorPeriodo")
                        .HasForeignKey("Modelo.Pagos.PagosPorPeriodo", "PeriodoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Periodo");
                });

            modelBuilder.Entity("Modelo.Pagos.Penalizacion", b =>
                {
                    b.HasOne("Modelo.Pagos.Estados", "Estados")
                        .WithOne("penalizacion")
                        .HasForeignKey("Modelo.Pagos.Penalizacion", "EstadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");
                });

            modelBuilder.Entity("Modelo.Pagos.Estados", b =>
                {
                    b.Navigation("configuraciones");

                    b.Navigation("pagos");

                    b.Navigation("penalizacion");
                });

            modelBuilder.Entity("Modelo.Pagos.Estudiante", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Modelo.Pagos.Periodo", b =>
                {
                    b.Navigation("Pagos");

                    b.Navigation("pagosPorPeriodo");
                });

            modelBuilder.Entity("Modelo.Pagos.TiposPago", b =>
                {
                    b.Navigation("Configuracion");

                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
