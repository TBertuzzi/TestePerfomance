using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePerfomance.Models;

namespace TestePerfomance.Repository
{
    public class ProdutoRepository
    {
        public static List<Produto> ObterProdutos()
        {
            var produtos = new List<Produto>
            {
                new Produto
                {
                    Id = 1, Name = "Pokemon Scarlet", Categoria = "Games",
                    Description = "Pokemon do Nintendo Switch",
                    ImgUrl = "https://someurl/firstimage",
                    Preco = 20.99
                },
                new Produto
                {
                    Id = 2, Name = "The Legend of Zelda",
                    Categoria = "Games",
                    Description = "Grande Zeldinha",
                    ImgUrl = "https://someurl/secondimage",
                    Preco = 30.99
                },
                new Produto
                {
                    Id = 3, Name = "Enduro", Categoria = "Games",
                    Description = "Ta véio em?",
                    ImgUrl = "https://someurl/thirdimage",
                    Preco = 19.99
                }
            };

            return produtos;
        }
    }
}
