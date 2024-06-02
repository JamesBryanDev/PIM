namespace PIM.Models
{
    public class Vendedor
    {
        public int id { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public decimal comissao { get; set; }
        public Endereco endereco { get; set; }
    }
}
