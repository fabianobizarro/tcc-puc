using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDropS.Dominio
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
    }
}
