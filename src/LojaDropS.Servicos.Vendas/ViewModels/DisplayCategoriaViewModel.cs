using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDropS.Dominio;

namespace LojaDropS.Servicos.Vendas.ViewModels
{
    public class DisplayCategoriaViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public static DisplayCategoriaViewModel Map(Categoria categoria)
        {
            if (categoria == null) return null;

            return new DisplayCategoriaViewModel
            {
                Id = categoria.Id.ToString(),
                Nome = categoria.Nome
            };
        }
    }
}
