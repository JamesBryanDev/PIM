using System.ComponentModel.DataAnnotations;

namespace PIM.Models
{
    public class Endereco
    {
        public int id { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        [MaxLength(2)]
        public string estado { get; set; }
        public string pais { get; set; }
    }
}
