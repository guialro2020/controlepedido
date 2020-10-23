using Microsoft.Extensions.DependencyInjection;
using Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Negocio.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Persistencia;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Servicos;

namespace Tcs.ControlePedido.Api
{
    public static class CqrsDependencyInjection
    {
        private static IServiceCollection InjetarServicos(this IServiceCollection services)
        {
            services.AddTransient<IClienteServico, ClienteServico>();

            return services;
        }

        private static IServiceCollection InjetarValidadores(this IServiceCollection services)
        {
            services.AddScoped<ApagarClienteValidador>();
            services.AddScoped<AtualizarClienteValidador>();
            services.AddScoped<CadastrarClienteValidador>();

            return services;
        }

        private static IServiceCollection InjetarCommands(this IServiceCollection services)
        {
            services.AddTransient<ICadastrarClienteCommand, CadastrarClienteCommand>();
            services.AddTransient<IAtualizarClienteCommand, AtualizarClienteCommand>();
            services.AddTransient<IApagarClienteCommand, ApagarClienteCommand>();

            return services;
        }

        private static IServiceCollection InjetarQueries(this IServiceCollection services)
        {
            services.AddTransient<IObterClientesQuery, ObterClientesQuery>();

            return services;
        }

        public static void InjetarDependencias(IServiceCollection services)
        {
            services.InjetarServicos()
                .InjetarValidadores()
                .InjetarCommands()
                .InjetarQueries();
        }
    }
}
