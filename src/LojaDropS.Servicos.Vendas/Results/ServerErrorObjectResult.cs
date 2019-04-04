using Microsoft.AspNetCore.Mvc;

namespace LojaDropS.Servicos.Vendas.Results
{
    public class ServerErrorObjectResult : ObjectResult
    {
        public ServerErrorObjectResult(object value)
            :base(value)
        {
            StatusCode = 500;
        }
    }
}
