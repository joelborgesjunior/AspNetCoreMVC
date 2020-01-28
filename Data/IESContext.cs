using AspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVC.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instituicao>()
                .HasMany(e => e.Departamentos)
                .WithOne(e => e.Instituicao)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
