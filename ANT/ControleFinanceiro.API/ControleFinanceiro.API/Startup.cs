using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ControleFinanceiro.DAL;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.DAL.Data;

namespace ControleFinanceiro.API
{
    public class Startup
    {

        private const string spaPath = "ControleFinanceiro-UI";
        private const string BaseUri = "http://localhost:4200/";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<Contexto>(o => o.UseSqlServer(Configuration.GetConnectionString("ConexaoDB")));

            services.AddDbContext<Contexto>(o => o.UseSqlServer(Configuration.GetConnectionString("ConexaoDB"), b => b.MigrationsAssembly("ControleFinanceiro.API")));

            //options.UseSqlServer(connection, b => b.MigrationsAssembly("ControleFinanceiro.API"))

            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<Contexto>();

            services.AddCors();

            services.AddSpaStaticFiles(diretorio =>
            {
                diretorio.RootPath = spaPath;
            });

            services.AddControllers().AddJsonOptions(opcoes =>
            {
                opcoes.JsonSerializerOptions.IgnoreNullValues = true;
            }).AddNewtonsoftJson(opcoes =>
            {
                opcoes.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opcoes =>
            {
                opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //app.UseSpa((Action<Microsoft.AspNetCore.SpaServices.ISpaBuilder>)(spa =>
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), spaPath);
                if (env.IsDevelopment()) {
                    spa.UseProxyToSpaDevelopmentServer(BaseUri);
                };
            });
        }
    }
}
