using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC.Models
{
    public class Departamento
    {
        [Key]
        public long? DepartamentoId { get; set; }

        public string Nome { get; set; }
    }
}
