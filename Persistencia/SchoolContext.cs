using Microsoft.EntityFrameworkCore;
using Modelo.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class SchoolContext : DbContext
    {
        public DbSet<Configuracion> configuracion { get; set; }
        public DbSet<Estados> estados { get; set; }
        public DbSet<Estudiante> estudiante { get; set; }
        public DbSet<Pagos> pagos { get; set; }
        public DbSet<PagosPorPeriodo> pagosPorPeriodo { get; set; }
        public DbSet<Penalizacion> penalizacion { get; set; }
        public DbSet<Periodo> periodo { get; set; }
        public DbSet<TiposPago> tiposPago{ get; set; }

        public SchoolContext() : base()
        {

        }

        public SchoolContext(DbContextOptions<SchoolContext> opciones)
            : base(opciones)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                EscuelaConfig.ContextOptions(optionsBuilder);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a muchos; un Estudiante tiene muchos Pagos 
            modelBuilder.Entity<Pagos>()
                .HasOne(pag => pag.Estudiante)
                .WithMany(est => est.Pagos)
                .HasForeignKey(pag => pag.EstudianteID);

            // Relación uno a muchos; un Periodo tiene muchos Pagos
            modelBuilder.Entity<Pagos>()
                .HasOne(pag => pag.Periodo)
                .WithMany(per => per.Pagos)
                .HasForeignKey(pag => pag.PeriodoID);

            // Relación uno a muchos; un TipoPago tiene muchos Pagos
            modelBuilder.Entity<Pagos>()
                .HasOne(pag => pag.TiposPago)
                .WithMany(tip => tip.Pagos)
                .HasForeignKey(pag => pag.TiposPagoID);

            // Relación uno a uno; un Estado tiene varios Pagos
            modelBuilder.Entity<Pagos>()
                .HasOne(pag => pag.Estados)
                .WithMany(est => est.pagos)
                .HasForeignKey(pag => pag.EstadoID);

            // Relación uno a uno; un PagosPeriodo tiene un Periodo
            modelBuilder.Entity<Periodo>()
                .HasOne(per => per.pagosPorPeriodo)
                .WithOne(ppp => ppp.Periodo)
                .HasForeignKey<PagosPorPeriodo>(ppp => ppp.PeriodoID);

            // Relación uno a uno; una Penalizacion tiene un Estado
            modelBuilder.Entity<Estados>()
                .HasOne(est => est.penalizacion)
                .WithOne(pen => pen.Estados)
                .HasForeignKey<Penalizacion>(pen => pen.EstadoID);

            // Relación uno a uno; una Configuracion tiene un TipoPago
            modelBuilder.Entity<TiposPago>()
                .HasOne(tip => tip.Configuracion)
                .WithOne(con => con.TiposPago)
                .HasForeignKey<Configuracion>(con => con.TipoID);

            // Relación uno a muchos; un Estado tiene muchas Configuraciones
            modelBuilder.Entity<Configuracion>()
                .HasOne(con => con.Estados)
                .WithMany(est => est.configuraciones)
                .HasForeignKey(con => con.EstadoID);
        }
     }
}
