using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDropS.Servicos.Autenticacao.Controllers
{
    [Authorize]
    public class ClaimsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}