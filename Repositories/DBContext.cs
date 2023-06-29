namespace CampanhaVacinacao.Repositories
{
    using CampanhaVacinacao.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("sua_connection_string_aqui");
        }
    }
}
