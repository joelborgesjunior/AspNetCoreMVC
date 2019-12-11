using AspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVC.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {

        }

        public DbSet<Instituicao> Institucoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
