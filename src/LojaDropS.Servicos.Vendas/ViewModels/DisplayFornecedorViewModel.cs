using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDropS.Dominio;

namespace LojaDropS.Servicos.Vendas.ViewModels
{
    public class DisplayFornecedorViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public static DisplayFornecedorViewModel Map(Fornecedor arg)
        {
            if (arg == null) return null;

            return new DisplayFornecedorViewModel
            {
                Id = arg.Id.ToString(),
                Nome = arg.Nome
            };
        }
    }
}
