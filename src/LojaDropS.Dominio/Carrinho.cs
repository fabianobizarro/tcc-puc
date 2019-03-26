using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDropS.Dominio
{
    public class Carrinho
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
