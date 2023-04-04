using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestePerfomance.Models;
using TestePerfomance.Repository;

namespace TestePerfomance
{
    [RankColumn]
    [MemoryDiagnoser]
    public class ServiceDemo
    {
        private readonly List<Produto> _produtos;
        public ServiceDemo()
        {
            _produtos = ProdutoRepository.ObterProdutos();
        }

        [Benchmark]
        public List<ProdutoDTO> ObterProtutoPorFor()
        {
            var retorno = new List<ProdutoDTO>();
            ProdutoDTO produtoDTO;
            for (int i = 0; i < _produtos.Count; i++)
            {
                produtoDTO = new ProdutoDTO
                {
                    Id = _produtos[i].Id,
                    Categoria = _produtos[i].Categoria,
                    Description = _produtos[i].Description,
                    ImgUrl = _produtos[i].ImgUrl,
                    Name = _produtos[i].Name,
                    Preco = _produtos[i].Preco
                };

                retorno.Add(produtoDTO);
            }

            return retorno;
        }

        [Benchmark]
        public List<ProdutoDTO> ObterProtutoPorForEach()
        {
            var retorno = new List<ProdutoDTO>();
            ProdutoDTO produtoDTO;

            foreach (var produto in _produtos)
            {
                produtoDTO = new ProdutoDTO
                {
                    Id = produto.Id,
                    Categoria = produto.Categoria,
                    Description = produto.Description,
                    ImgUrl = produto.ImgUrl,
                    Name = produto.Name,
                    Preco = produto.Preco
                };

                retorno.Add(produtoDTO);

            }

            return retorno;
        }

        [Benchmark]
        public List<ProdutoDTO> ObterProtutoPorLinq()
        {
            IEnumerable<ProdutoDTO> retorno =
                _produtos.Select(x =>
                {
                    return new ProdutoDTO()
                    {
                        Id = x.Id,
                        Categoria = x.Categoria,
                        Description = x.Description,
                        ImgUrl = x.ImgUrl,
                        Name = x.Name,
                        Preco = x.Preco
                    };
                });

            return retorno.ToList();
        }
    }
}
