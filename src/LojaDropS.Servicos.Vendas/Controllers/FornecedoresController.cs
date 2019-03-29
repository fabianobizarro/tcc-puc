using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDropS.Infra.Interfaces;
using LojaDropS.Servicos.Vendas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaDropS.Servicos.Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoreStore _store;

        public FornecedoresController(IFornecedoreStore store)
        {
            _store = store;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fornecedores = await _store.Fornecedores
                .ToListAsync();

            var vm = fornecedores.Select(DisplayFornecedorViewModel.Map);

            return Ok(vm);
        }
    }
}