namespace PIM.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public long cpf { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Endereco endereco { get; set; }
    }
}
