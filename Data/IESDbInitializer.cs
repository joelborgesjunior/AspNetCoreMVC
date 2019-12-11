using AspNetCoreMVC.Models;
using System.Linq;

namespace AspNetCoreMVC.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departamentos.Any())
            {
                return;
            }

            var Departamentos = new Departamento[]
            {
                new Departamento {Nome="Ciência da Computação"},
                new Departamento {Nome="Ciência de Alimentos"}
            };

            foreach (Departamento d in Departamentos)
            {
                context.Departamentos.Add(d);
            }

            context.SaveChanges();
        }
    }
}
