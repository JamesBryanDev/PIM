namespace PIM.Models
{
    public class Carrinho
    {
        public int id { get; set; }
        public DateTime dataPedido { get; set; }
        public decimal valorTotal { get; set; }
        public int statusPedido { get; set; }
        public Cliente cliente { get; set; }
        public List<Produto> produto { get; set; } = [];
    }
}
