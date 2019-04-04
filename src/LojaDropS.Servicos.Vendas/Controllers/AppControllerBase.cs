using LojaDropS.Servicos.Vendas.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDropS.Servicos.Vendas.Controllers
{
    public class AppControllerBase : ControllerBase
    {
        public ServerErrorResult Error()
        {
            return new ServerErrorResult();
        }

        public ServerErrorObjectResult Error(object value)
        {
            return new ServerErrorObjectResult(value);
        }
    }
}
