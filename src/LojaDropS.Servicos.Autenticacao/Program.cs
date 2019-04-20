using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LojaDropS.Servicos.Autenticacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = CreateLogger();

            CreateWebHostBuilder(args).Build().Run();
        }

        private static Serilog.ILogger CreateLogger() => new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("app.log")
                .WriteTo.Console()
                .CreateLogger();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
