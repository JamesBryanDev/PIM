using System.Text.Json.Serialization;

namespace PIM.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        [JsonIgnore]
        public List<Produto> produtos { get; set; } = [];
    }
}
