using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDropS.Servicos.Vendas.Controllers
{
    public class AppControllerBase : ControllerBase
    {
        public IActionResult Error()
        {
            return new StatusCodeResult(500);
        }
    }
}
