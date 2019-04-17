using System.ComponentModel.DataAnnotations;

namespace LojaDropS.Servicos.Vendas.ViewModels
{
    public class CadastroCategoriaViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

    }
}
