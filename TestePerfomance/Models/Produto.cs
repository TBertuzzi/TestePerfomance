using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestePerfomance.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Preco { get; set; }
        public string Categoria { get; set; } = null!;
        public string ImgUrl { get; set; } = null!;
    }

    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(List<Produto>))]
    public partial class ProdutoGenerationContext : JsonSerializerContext
    {
    }
}

