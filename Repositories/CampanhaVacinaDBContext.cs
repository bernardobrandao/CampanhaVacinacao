using CampanhaVacinacao.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CampanhaVacinacao.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Solicitantes> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
    }
}


