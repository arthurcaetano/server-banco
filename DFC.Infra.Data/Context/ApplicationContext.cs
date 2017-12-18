using System.IO;
using DFC.Domain;
using DFC.Infra.Data.Extensions;
using DFC.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DFC.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BancoMapping());
            modelBuilder.AddConfiguration(new ContaMapping());
            modelBuilder.AddConfiguration(new MovimentacaoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }
    }
}