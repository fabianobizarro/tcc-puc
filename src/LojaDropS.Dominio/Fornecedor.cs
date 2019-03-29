using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDropS.Dominio
{
    public class Fornecedor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }

        public Fornecedor() { }

        public Fornecedor(string nome)
        {
            Nome = nome;
        }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
