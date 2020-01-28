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

            var instituicoes = new Instituicao[]
{
            new Instituicao {Nome="UniParaná", Endereço="Paraná"},
            new Instituicao {Nome="UniAcre", Endereço="Acre"}
};
            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }

            context.SaveChanges();

            var Departamentos = new Departamento[]
            {
            new Departamento {Nome="Ciência da Computação", InstituicaoId=1},
            new Departamento {Nome="Ciência de Alimentos", InstituicaoId=2}
            };

            foreach (Departamento d in Departamentos)
            {
                context.Departamentos.Add(d);
            }

            context.SaveChanges();
        }
    }
}
