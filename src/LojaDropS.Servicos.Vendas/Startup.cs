﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using LojaDropS.Infra.Interfaces;
using LojaDropS.Infra.Stores;
using LojaDropS.Infra;
using Microsoft.IdentityModel.Logging;
using IdentityServer4.AccessTokenValidation;
using Microsoft.Extensions.Caching.Distributed;

namespace LojaDropS.Servicos.Vendas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options.UseInMemoryDatabase("poctccpuc");
                //options.UseSqlite(@"Data Source=mydb.db");
            });

            services.AddTransient<IAppDbContext, AppDbContext>();
            services.AddTransient<IProdutoStore, ProdutoStore>();
            services.AddTransient<ICategoriaStore, CategoriaStore>();
            services.AddTransient<IFornecedoreStore, FornecedorStore>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:5000";
                    options.ApiName = "apiVendas";
                    options.ApiSecret = "iTqp9@&9EQAbEv";
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    
                    options.EnableCaching = true;
                    options.CacheDuration = TimeSpan.FromDays(5);

                });

            services.AddTransient<IDistributedCache, MemoryDistributedCache>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("admin");
                });

                options.AddPolicy("Fornecedor", policy =>
                {
                    policy.RequireAssertion(a =>
                    {
                        return a.User.IsInRole("fornecedor") || a.User.IsInRole("admin");
                    });
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AppPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            InitializeDb(serviceProvider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public void InitializeDb(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Initializing Db");
            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                //context.Database.Migrate();
                DB.MoqDb(context);
            }
            Console.WriteLine("Finished");
        }

    }
}
