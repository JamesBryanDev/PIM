using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIM.Models
{
    public class Produto
    {
        public int id { get; set; }
        [MaxLength(45)]
        public string descricao { get; set; }
        public decimal preco { get; set; }
        [MaxLength(200)]
        public string imagem { get; set; }
        public string status { get; set; }
        public int vendedorId { get; set; }
        public int categoriaId { get; set; }
        [JsonIgnore]
        public Vendedor vendedor { get; set; }
        [JsonIgnore]
        public Categoria categoria { get; set; }
        [JsonIgnore]
        public List<ItemCarrinho> carrinho { get; set; } = [];
    }
}
