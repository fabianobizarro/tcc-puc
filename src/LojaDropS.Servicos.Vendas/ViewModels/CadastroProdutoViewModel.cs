using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDropS.Servicos.Vendas.ViewModels
{
    public class CadastroProdutoViewModel
    {
        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(100, ErrorMessage ="Tamanho maximo de {0} caracteres")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage ="Campo obrigatorio")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string FornecedorId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string CategoriaId { get; set; }

        public IDictionary<string, string> Propriedades { get; set; }
    }
}
