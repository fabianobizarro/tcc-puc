using LojaDropS.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaDropS.Infra.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Produto> Produtos { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<SubCategoria> Subcategorias { get; set; }
        DbSet<Fornecedor> Fornecedores { get; set; }
        DbSet<Carrinho> Carrinhos { get; set; }
        DbSet<Caracteristica> Caracteristicas { get; set; }

        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
