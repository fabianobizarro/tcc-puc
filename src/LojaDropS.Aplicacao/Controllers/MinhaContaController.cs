using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDropS.Aplicacao.Controllers
{
    [Authorize]
    public class MinhaContaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}