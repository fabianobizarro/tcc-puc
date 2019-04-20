using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using System;

namespace LojaDropS.Servicos.Vendas
{
    public class DB
    {
        private static readonly RandomGenerator Random = new RandomGenerator(new Random());

        public static List<Categoria> GetCategorias()
        {
            return new List<Categoria>
            {
                new Categoria("Categoria 1"),
                new Categoria("Categoria 2"),
                new Categoria("Categoria 3"),
                new Categoria("Categoria 4"),
                new Categoria("Categoria 5"),
                new Categoria("Categoria 6")
            };
        }

        public static List<Fornecedor> GetFornecedors()
        {
            var categoria1 = GetCategorias().First();
            var categoria2 = GetCategorias()[1];

            var fornecedor1 = new Fornecedor("Fornecedor 1");
            fornecedor1.Produtos = Builder<Produto>.CreateListOfSize(20)
                                    .All()
                                    .Do(p => p.CategoriaId = Random.Int() % 2 == 0 ? categoria1.Id : categoria2.Id)
                                    .Do(p => p.UrlImagem = "https://via.placeholder.com/250x150")
                                    .Do(p => p.Caracteristicas = GetRandomCaracteristicas())
                                    .Build();

            var fornecedor2 = new Fornecedor("Fornecedor 2");
            fornecedor2.Produtos = Builder<Produto>.CreateListOfSize(15)
                                    .All()
                                    .Do(p => p.CategoriaId = Random.Int() % 2 == 0 ? categoria1.Id : categoria2.Id)
                                    .Do(p => p.Caracteristicas = GetRandomCaracteristicas())
                                    .Do(p => p.UrlImagem = "https://via.placeholder.com/250x150")
                                    .Build();

            return new List<Fornecedor>
            {
                fornecedor1,
                fornecedor2
            };

            //return new List<Fornecedor>
            //{
            //    new Fornecedor("Fornecedor 1")
            //    {
            //        Produtos = new List<Produto>
            //        {
            //            new Produto
            //            {
            //                Nome = "Produto 1",
            //                Descricao = "Descricao produto 1",
            //                CategoriaId = GetCategorias().First().Id,
            //                Valor = 100,
            //                Caracteristicas = new List<Caracteristica>
            //                {
            //                    new Caracteristica("Cor", "Preta"),
            //                    new Caracteristica("Peso", "100g"),
            //                    new Caracteristica("Altura", "10cm"),
            //                }
            //            },
            //            new Produto
            //            {
            //                Nome = "Produto 2",
            //                Descricao = "Descricao produto 2",
            //                CategoriaId = GetCategorias().First().Id,
            //                Valor = 99.99M,
            //                Caracteristicas = new List<Caracteristica>
            //                {
            //                    new Caracteristica("Cor", "Branca"),
            //                    new Caracteristica("Peso", "100kg"),
            //                    new Caracteristica("Altura", "1m"),
            //                }
            //            }
            //        }
            //    },
            //    new Fornecedor("Fornecedor 2"),
            //};
        }

        private static ICollection<Caracteristica> GetRandomCaracteristicas()
        {
            int propSize = Random.Next(1, 15);

            return Builder<Caracteristica>
                .CreateListOfSize(propSize)
                .Build();
        }

        public static void MoqDb(IAppDbContext context)
        {

            context.Categorias.AddRange(GetCategorias());
            context.SaveChanges();

            context.Fornecedores.AddRange(GetFornecedors());
            context.SaveChanges();
        }
    }
}
