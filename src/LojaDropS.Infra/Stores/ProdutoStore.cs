using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDropS.Infra.Stores
{
    public class ProdutoStore : BaseStore<Produto>, IProdutoStore
    {
        private readonly IAppDbContext _db;

        public ProdutoStore(IAppDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IQueryable<Produto> Produtos => _db.Produtos
            .Include(p => p.Caracteristicas)
            .Include(p => p.Categoria)
            .Include(P => P.Fornecedor);
    }
}
