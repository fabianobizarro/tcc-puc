using LojaDropS.Dominio;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDropS.Infra.Interfaces
{
    public interface IProdutoStore
    {
        IQueryable<Produto> Produtos { get; }
        Task<Produto> AddAsync(Produto produto);
        Task<Produto> UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}
