using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDropS.Dominio
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid CategoriaId { get; set; }
        public string UrlImagem { get; set; }

        public IDictionary<string, string> CaracteristicasToDict()
        {
            return Caracteristicas?.ToDictionary(
                key => key.Nome,
                value => value.Valor
            );
        }

        public virtual ICollection<Caracteristica> Caracteristicas { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
