using Microsoft.AspNetCore.Mvc;

namespace LojaDropS.Servicos.Vendas.Results
{
    public class ServerErrorResult : StatusCodeResult
    {
        public ServerErrorResult()
            : base(500)
        {

        }
    }
}
