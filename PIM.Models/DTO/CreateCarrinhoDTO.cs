namespace PIM.Models.DTO
{
    public class CreateCarrinhoDTO
    {
        public int clienteId { get; set; }
        public DateTime dataPedido { get; set; }
        public int statusPedido { get; set; }
        public List<ItemCarrinhoDTO> itens { get; set; }
    }
}
