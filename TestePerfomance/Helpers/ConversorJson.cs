using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestePerfomance.Models;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using TestePerfomance.Repository;

namespace TestePerfomance.Helpers
{
    //[RPlotExporter]
    [RankColumn]
    [MemoryDiagnoser]
    public class JsonHelper
    {
        private readonly List<Produto> _produtos;
        private readonly JsonSerializerOptions _jsonOptions;
        public JsonHelper()
        {
            _jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            _produtos = ProdutoRepository.ObterProdutos();
        }

        [Benchmark]
        public string Newtonsoft() => JsonConvert.SerializeObject(_produtos);

        [Benchmark]
        public string SystemTextJson() => System.Text.Json.JsonSerializer.Serialize(_produtos, _jsonOptions);

        [Benchmark]
        public string SourceGenerator() => System.Text.Json.JsonSerializer.Serialize(_produtos,
            ProdutoGenerationContext.Default.ListProduto);
    }
}
