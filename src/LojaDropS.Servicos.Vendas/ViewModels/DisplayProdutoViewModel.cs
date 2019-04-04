using LojaDropS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDropS.Servicos.Vendas.ViewModels
{
    public class DisplayProdutoViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string FornecedorId { get; set; }
        public string CategoriaId { get; set; }
        public virtual IDictionary<string, string> Caracteristicas { get; set; }

        public static DisplayProdutoViewModel Map(Produto produto)
        {
            if (produto == null)
                return null;

            return new DisplayProdutoViewModel
            {
                Id = produto.Id.ToString(),
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                FornecedorId = produto.FornecedorId.ToString(),
                CategoriaId = produto.CategoriaId.ToString(),
                Caracteristicas = produto.CaracteristicasToDict()
            };
        }

    }
}
