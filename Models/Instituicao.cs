using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC.Models
{
    public class Instituicao
    {
        [Key]
        public long? Id{ get; set; }

        public string Nome { get; set; }
        public string Endereço { get; set; }
    }
}
