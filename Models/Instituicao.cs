using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC.Models
{
    public class Instituicao
    {
        [Key]
        public long? IdInstituicao { get; set; }
        
        public string NomeInstituicao { get; set; }
        public string EndereçoInstituicao { get; set; }
    }
}
