using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDropS.Dominio
{
    public class SubCategoria : Categoria
    {
        public Guid CategoriaPaiId { get; set; }
        public virtual Categoria CategoriaPai { get; set; }

        public SubCategoria() { }


        public SubCategoria(string nome)
            : base(nome)
        {
        }

    }
}
