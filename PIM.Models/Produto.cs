namespace PIM.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public string imagem { get; set; }
        public string status { get; set; }
        public Vendedor vendedor { get; set; }
        public Categoria categoria { get; set; }
    }
}
