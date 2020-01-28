using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC.Models
{
    public class Departamento
    {
        [Key]
        public long? DepartamentoId { get; set; }
        public string Nome { get; set; }

        public long? InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }

    }
}
