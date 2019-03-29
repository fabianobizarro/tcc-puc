using System;
using System.Collections.Generic;

namespace LojaDropS.Dominio
{
    public class Caracteristica
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }

        public string Nome { get; set; }
        public string Valor { get; set; }


        public Caracteristica()
        {
            Id = Guid.NewGuid();
        }

        public Caracteristica(string nome, string valor)
            :this()
        {
            Nome = nome;
            Valor = valor;
        }

        public virtual Produto Produto { get; set; }
    }
}