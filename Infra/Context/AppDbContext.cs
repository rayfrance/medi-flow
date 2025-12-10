using MediFlow.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.Web.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Cirurgia> Cirurgias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed de dados para teste
            modelBuilder.Entity<Sala>().HasData(
                new { Id = 1, Nome = "Sala Cardíaca", Numero = 101 },
                new { Id = 2, Nome = "Sala Ortopédica", Numero = 102 }
            );
            modelBuilder.Entity<Paciente>().HasData(
                new { Id = 1, Nome = "João Silva", Cpf = "111.111.111-11" },
                new { Id = 2, Nome = "Maria Souza", Cpf = "222.222.222-22" }
            );
        }
    }
}