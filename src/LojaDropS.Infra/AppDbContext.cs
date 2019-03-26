using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaDropS.Infra
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> Subcategorias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

    }
}
