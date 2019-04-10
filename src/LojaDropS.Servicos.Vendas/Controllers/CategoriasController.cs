﻿using System;
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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaStore _store;

        public CategoriasController(ICategoriaStore store)
        {
            _store = store;
        }

        public async Task<IActionResult> Get()
        {
            var categorias = await _store.Categorias.ToListAsync();

            var vm = categorias.Select(DisplayCategoriaViewModel.Map);

            return Ok(vm);
        }
    }
}