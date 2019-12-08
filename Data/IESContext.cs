using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVC.Models;

namespace AspNetCoreMVC.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base (options)
        {

        }

        public DbSet<Instituicao> Institucoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
