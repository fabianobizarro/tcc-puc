using System;

namespace LojaDropS.Dominio
{
    public class Caracteristica
    {
        public int Id { get; set; }
        public Guid ProdutoId { get; set; }

        public string Nome { get; set; }
        public string Valor { get; set; }

        public virtual Produto Produto { get; set; }
    }
}