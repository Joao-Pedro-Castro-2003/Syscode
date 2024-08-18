using Microsoft.EntityFrameworkCore;
using Syscode.Models;

namespace Syscode.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<PopulacaoModel> Population { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PopulacaoModel>()
                .HasNoKey(); 
        }
    }
}
