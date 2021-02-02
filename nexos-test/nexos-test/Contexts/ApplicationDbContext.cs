using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nexos_test.Models;


namespace nexos_test.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitasModel>()
                .HasKey(x => new { x.CitaDoctorID, x.CitaPacienteID });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DoctoresModel> Doctores { get; set; }
        public DbSet<PacientesModel> Pacientes { get; set; }
        public DbSet<CitasModel> Citas { get; set; }
    }
}
