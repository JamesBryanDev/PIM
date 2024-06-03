using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIM.Models
{
    public class Vendedor
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string razaoSocial { get; set; }
        [MaxLength(70)]
        public string nomeFantasia { get; set; }
        [MaxLength(18)]
        public string cnpj { get; set; }
        [MaxLength(70)]
        public string email { get; set; }
        [MaxLength(25)]
        public string senha { get; set; }
        public decimal comissao { get; set; }
        public int enderecoId { get; set; }
        public Endereco endereco { get; set; }
        [JsonIgnore]
        public virtual List<Produto> produtos { get; set; }
    }
}
