using Microsoft.Extensions.DependencyInjection;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Servicos;

namespace Tcs.ControlePedido.Api
{
    public static class ControlePedidoIoc
    {
        private static IServiceCollection InjetarServicos(this IServiceCollection services)
        {
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();
            services.AddScoped<IFreteServico, FreteServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();

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

            services.AddScoped<Negocio.Produtos.Commands.ApagarProduto.ApagarProdutoValidador>();
            services.AddScoped<Negocio.Produtos.Commands.AtualizarProduto.AtualizarProdutoValidador>();
            services.AddScoped<Negocio.Produtos.Commands.CadastrarProduto.CadastrarProdutoValidador>();

            services.AddScoped<Negocio.Transporte.Queries.ObterFrete.ObterFreteValidador>();

            services.AddScoped<Negocio.Fiscal.Queries.ObterNotaFiscal.ObterNotaFiscalValidador>();

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

            services.AddTransient<Negocio.Core.Produtos.Commands.CadastrarProduto.ICadastrarProdutoCommand, Negocio.Produtos.Commands.CadastrarProduto.CadastrarProdutoCommand>();
            services.AddTransient<Negocio.Core.Produtos.Commands.AtualizarProduto.IAtualizarProdutoCommand, Negocio.Produtos.Commands.AtualizarProduto.AtualizarProdutoCommand>();
            services.AddTransient<Negocio.Core.Produtos.Commands.ApagarProduto.IApagarProdutoCommand, Negocio.Produtos.Commands.ApagarProduto.ApagarProdutoCommand>();

            services.AddTransient<Negocio.Core.Transporte.Queries.ObterFrete.IObterFreteQuery, Negocio.Transporte.Queries.ObterFrete.ObterFreteQuery>();

            services.AddTransient<Negocio.Core.Fiscal.Queries.ObterNotaFiscal.IObterNotaFiscalQuery, Negocio.Fiscal.Queries.ObterNotaFiscal.ObterNotaFiscalQuery>();

            return services;
        }

        private static IServiceCollection InjetarQueries(this IServiceCollection services)
        {
            services.AddTransient<Negocio.Core.Clientes.Queries.ObterClientes.IObterClientesQuery, Negocio.Clientes.Queries.ObterClientes.ObterClientesQuery>();
            services.AddTransient<Negocio.Core.Pedidos.Queries.ObterPedidos.IObterPedidosQuery, Negocio.Pedidos.Queries.ObterPedidos.ObterPedidosQuery>();
            services.AddTransient<Negocio.Core.Produtos.Queries.ObterProdutos.IObterProdutosQuery, Negocio.Produtos.Queries.ObterProdutos.ObterProdutosQuery>();

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
