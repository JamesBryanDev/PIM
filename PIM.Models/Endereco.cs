using System.ComponentModel.DataAnnotations;

namespace PIM.Models
{
    public class Endereco
    {
        public int id { get; set; }
        [MaxLength(256)]
        public string rua { get; set; }
        [MaxLength(100)]
        public string bairro { get; set; }
        [MaxLength(200)]
        public string cidade { get; set; }
        [MaxLength(2)]
        public string estado { get; set; }
        [MaxLength(150)]
        public string pais { get; set; }
    }
}
