using System;
using System.Linq;
using System.Threading.Tasks;
using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using LojaDropS.Servicos.Vendas.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaDropS.Servicos.Vendas.Controllers
{
    [ApiController]
    [Authorize("Admin")]
    [EnableCors("AppPolicy")]
    [Route("api/[controller]")]
    public class CategoriasController : AppControllerBase
    {
        private readonly ICategoriaStore _store;

        public CategoriasController(ICategoriaStore store)
        {
            _store = store;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var categorias = await _store.Categorias
                .ToListAsync();

            var vm = categorias.Select(DisplayCategoriaViewModel.Map);

            return Ok(vm);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var categoria = await _store.Categorias
                .FirstOrDefaultAsync(p => p.Id == id);

            var vm = DisplayCategoriaViewModel.Map(categoria);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CadastroCategoriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _store.AddAsync(new Categoria(model.Nome));
                var vm = DisplayCategoriaViewModel.Map(result);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]CadastroCategoriaViewModel model)
        {
            try
            {
                var categoria = await _store.Categorias.FirstOrDefaultAsync(p => p.Id == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    categoria.Nome = model.Nome;
                    var result = await _store.UpdateAsync(categoria);

                    var vm = DisplayCategoriaViewModel.Map(result);

                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var categoria = await _store.Categorias.FirstOrDefaultAsync(p => p.Id == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                await _store.DeleteAsync(categoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}