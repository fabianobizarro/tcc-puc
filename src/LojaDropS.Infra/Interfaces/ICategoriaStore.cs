using LojaDropS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDropS.Infra.Interfaces
{
    public interface ICategoriaStore : IBaseStore<Categoria>
    {
        IQueryable<Categoria> Categorias { get; }
    }
}
