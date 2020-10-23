using Microsoft.Extensions.DependencyInjection;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Servicos;

namespace Tcs.ControlePedido.Api
{
    public static class ControlePedidoIoc
    {
        private static IServiceCollection InjetarServicos(this IServiceCollection services)
        {
            services.AddTransient<IClienteServico, ClienteServico>();
            services.AddTransient<IPedidoServico, PedidoServico>();

            return services;
        }

        private static IServiceCollection InjetarValidadores(this IServiceCollection services)
        {
            services.AddScoped<Negocio.Clientes.Commands.ApagarCliente.ApagarClienteValidador>();
            services.AddScoped<Negocio.Clientes.Commands.AtualizarCliente.AtualizarClienteValidador>();
            services.AddScoped<Negocio.Clientes.Commands.CadastrarCliente.CadastrarClienteValidador>();

            services.AddScoped<Negocio.Pedidos.Commands.ApagarPedido.ApagarPedidoValidador>();
            services.AddScoped<Negocio.Pedidos.Commands.AtualizarPedido.AtualizarPedidoValidador>();
            services.AddScoped<Negocio.Pedidos.Commands.CadastrarPedido.CadastrarPedidoValidador>();

            return services;
        }

        private static IServiceCollection InjetarCommands(this IServiceCollection services)
        {
            services.AddTransient<Negocio.Core.Clientes.Commands.CadastrarCliente.ICadastrarClienteCommand, Negocio.Clientes.Commands.CadastrarCliente.CadastrarClienteCommand>();
            services.AddTransient<Negocio.Core.Clientes.Commands.AtualizarCliente.IAtualizarClienteCommand, Negocio.Clientes.Commands.AtualizarCliente.AtualizarClienteCommand>();
            services.AddTransient<Negocio.Core.Clientes.Commands.ApagarCliente.IApagarClienteCommand, Negocio.Clientes.Commands.ApagarCliente.ApagarClienteCommand>();

            services.AddTransient<Negocio.Core.Pedidos.Commands.CadastrarPedido.ICadastrarPedidoCommand, Negocio.Pedidos.Commands.CadastrarPedido.CadastrarPedidoCommand>();
            services.AddTransient<Negocio.Core.Pedidos.Commands.AtualizarPedido.IAtualizarPedidoCommand, Negocio.Pedidos.Commands.AtualizarPedido.AtualizarPedidoCommand>();
            services.AddTransient<Negocio.Core.Pedidos.Commands.ApagarPedido.IApagarPedidoCommand, Negocio.Pedidos.Commands.ApagarPedido.ApagarPedidoCommand>();

            return services;
        }

        private static IServiceCollection InjetarQueries(this IServiceCollection services)
        {
            services.AddTransient<Negocio.Core.Clientes.Queries.ObterClientes.IObterClientesQuery, Negocio.Clientes.Queries.ObterClientes.ObterClientesQuery>();
            services.AddTransient<Negocio.Core.Pedidos.Queries.ObterPedidos.IObterPedidosQuery, Negocio.Pedidos.Queries.ObterPedidos.ObterPedidosQuery>();

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
