using System.Text.Json.Serialization;

namespace PIM.Models
{
    public class Carrinho
    {
        public int id { get; set; }
        public DateTime dataPedido { get; set; }
        public decimal valorTotal { get; set; }
        public int statusPedido { get; set; }
        public int clienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente cliente { get; set; }
        public virtual List<ItemCarrinho> produtos { get; set; } = [];
    }
}
