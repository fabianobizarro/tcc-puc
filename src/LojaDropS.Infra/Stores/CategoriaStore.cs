using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDropS.Infra.Stores
{
    public class CategoriaStore : BaseStore<Categoria>, ICategoriaStore
    {
        private readonly IAppDbContext _context;

        public CategoriaStore(IAppDbContext context)
            :base(context)
        {
            _context = context;
        }

        public IQueryable<Categoria> Categorias => _context.Categorias;
    }
}
