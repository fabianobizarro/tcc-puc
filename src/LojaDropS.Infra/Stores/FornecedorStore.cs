using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDropS.Infra.Stores
{
    public class FornecedorStore : BaseStore<Fornecedor>, IFornecedoreStore
    {
        private readonly IAppDbContext _context;

        public FornecedorStore(IAppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<Fornecedor> Fornecedores => _context.Fornecedores;
    }
}
