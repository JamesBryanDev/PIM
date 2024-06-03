using System.Text.Json.Serialization;

namespace PIM.Models
{
    public class ItemCarrinho
    {
        public int carrinhoId { get; set; }
        public int produtoId { get; set; }
        public int quantidade { get; set; }
        public decimal total { get; set; }
        [JsonIgnore]
        public virtual Carrinho carrinho { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
    }
}
