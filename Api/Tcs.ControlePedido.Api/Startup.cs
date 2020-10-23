using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Tcs.ControlePedido.Api.Extensoes;
using Tcs.ControlePedido.Logger;
using Tcs.ControlePedido.Persistencia;

namespace Tcs.ControlePedido.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersistenciaContexto>(opt => opt.UseInMemoryDatabase());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ControlePedidoIoc.InjetarDependencias(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Controle de Pedidos",
                        Version = "v1",
                        Description = "Controle de Pedidos"
                    });

                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
            });
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new ProvedorLogCustomizado(new ProvedorLogCustomizadoConfiguration
            {
                LogLevel = LogLevel.Information
            }));

            app.UseGlobalExceptionHandler(loggerFactory);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Controle de Pedidos");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
