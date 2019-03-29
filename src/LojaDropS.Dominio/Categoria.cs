using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDropS.Dominio
{
    public class Categoria
    {
        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }

        public ICollection<SubCategoria> SubCategorias { get; set; }
    }
}
