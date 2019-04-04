using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using LojaDropS.Servicos.Vendas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaDropS.Servicos.Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : AppControllerBase
    {
        private readonly IProdutoStore _store;
        const int DefaultDisplaySize = 20;
        const int DefaultPage = 1;

        public ProdutosController(IProdutoStore repo)
        {
            _store = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string q,
            [FromQuery]int page = DefaultPage,
            [FromQuery]int display = DefaultDisplaySize)
        {
            var produtos = _store.Produtos;

            if (!string.IsNullOrEmpty(q))
            {
                q = q.ToLower();
                produtos = produtos.Where(p => p.Nome.ToLower().Contains(q) || p.Descricao.ToLower().Contains(q));
            }

            var skip = page == 1 ? 0 : page * display;

            produtos = produtos.Skip(skip).Take(display);

            var list = await Task.FromResult(produtos.ToList());

            var vm = list.Select(DisplayProdutoViewModel.Map);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastroProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = new Produto()
                    {
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        CategoriaId = new Guid(model.CategoriaId),
                        FornecedorId = new Guid(model.FornecedorId),
                        Valor = model.Valor,
                        Caracteristicas = model?.Caracteristicas.Select(p => new Caracteristica
                        {
                            Nome = p.Key,
                            Valor = p.Value,
                        }).ToList()
                    };

                    var result = await _store.AddAsync(produto);

                    var vm = DisplayProdutoViewModel.Map(result);

                    return Ok(vm);
                }
                catch (Exception ex)
                {
                    return Error(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}