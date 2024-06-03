using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIM.Models
{
    public class Cliente
    {
        public int id { get; set; }
        [MaxLength(256)]
        public string nome { get; set; }
        public long cpf { get; set; }
        [MaxLength(70)]
        public string email { get; set; }
        [MaxLength(25)]
        public string senha { get; set; }
        public int enderecoId { get; set; }
        public Endereco endereco { get; set; }
        [JsonIgnore]
        public virtual List<Carrinho> carrinhos { get; set; }
    }
}
