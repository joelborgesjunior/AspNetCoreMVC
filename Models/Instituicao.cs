using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Models
{
    public class Instituicao
    {
        public long? IdInstituicao { get; set; }
        public string NomeInstituicao { get; set; }
        public string EndereçoInstituicao { get; set; }
    }
}
