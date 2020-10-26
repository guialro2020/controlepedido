using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Negocio.Produtos.Queries.ObterProdutos;
using Tcs.ControlePedido.Negocio.Transporte.Queries.ObterFrete;
using Tcs.ControlePedido.Persistencia.Modelos;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Pedidos;

namespace Tcs.ControlePedido.Testes.Pedidos
{
    [TestFixture]
    public class CadastrarPedidoTesteUnidade
    {
        private CadastrarPedidosInput cadastrarPedidoInputSucesso = new CadastrarPedidosInput
        {
            DataPedido = DateTime.Now,
            ClienteId = 1,
            ItensPedido = new List<ProdutoPedido>
                {
                    new ProdutoPedido
                    {
                        CodigoProduto = 1,
                        Quantidade = 51
                    },
                    new ProdutoPedido
                    {
                        CodigoProduto = 2,
                        Quantidade = 32
                    }
                }
        };

        [Test]
        public async Task CadastrarPedidoSucesso()
        {
            var freteServiceMock = new FreteServicoMock();
            var freteServico = freteServiceMock.ConfigurarObterFretePeloId().Build();
            var obterFreteQuery = new ObterFreteQuery(freteServico, new ObterFreteValidador(freteServico));

            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloId().ConfigurarObterClientes().Build();
            var obterClientesQuery = new ObterClientesQuery(clienteServico);

            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarObterProdutoPeloId().ConfigurarContarProdutosPorId().Build();
            var obterProdutoQuery = new ObterProdutosQuery(produtoServico);

            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarPedidoCommand(pedidoServico,
                obterFreteQuery,
                obterClientesQuery,
                obterProdutoQuery,
                new CadastrarPedidoValidador(clienteServico, produtoServico));

            var resultado = await cadastrarCommand.Executar(cadastrarPedidoInputSucesso);

            Assert.GreaterOrEqual(1, resultado.NumeroPedido);
        }

        [Test]
        public async Task CadastrarPedidoFreteNaoEncontrado()
        {
            var freteServiceMock = new FreteServicoMock();
            var freteServico = freteServiceMock.ConfigurarObterFretePeloIdInexistente().Build();
            var obterFreteQuery = new ObterFreteQuery(freteServico, new ObterFreteValidador(freteServico));

            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloId().ConfigurarObterClientes().Build();
            var obterClientesQuery = new ObterClientesQuery(clienteServico);

            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarObterProdutoPeloId().ConfigurarContarProdutosPorId().Build();
            var obterProdutoQuery = new ObterProdutosQuery(produtoServico);

            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarPedidoCommand(pedidoServico,
                obterFreteQuery,
                obterClientesQuery,
                obterProdutoQuery,
                new CadastrarPedidoValidador(clienteServico, produtoServico));

            var resultado = await cadastrarCommand.Executar(cadastrarPedidoInputSucesso);

            Assert.GreaterOrEqual(1, resultado.NumeroPedido);
        }

        [Test]
        public void CadastrarPedidoClienteSemCep()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloId().Build();
            var obterClientesQuery = new ObterClientesQuery(clienteServico);

            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarObterProdutoPeloId().ConfigurarContarProdutosPorId().Build();
            var obterProdutoQuery = new ObterProdutosQuery(produtoServico);

            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarPedidoCommand(pedidoServico,
                null,
                obterClientesQuery,
                null,
                new CadastrarPedidoValidador(clienteServico, produtoServico));

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(cadastrarPedidoInputSucesso));
        }

        [Test]
        public void CadastrarPedidoClienteInexistente()
        {
            var freteServiceMock = new FreteServicoMock();
            var freteServico = freteServiceMock.ConfigurarObterFretePeloId().Build();
            var obterFreteQuery = new ObterFreteQuery(freteServico, new ObterFreteValidador(freteServico));

            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloIdInexistente().Build();
            var obterClientesQuery = new ObterClientesQuery(clienteServico);

            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarObterProdutoPeloId().Build();
            var obterProdutoQuery = new ObterProdutosQuery(produtoServico);

            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarPedidoCommand(pedidoServico,
                obterFreteQuery,
                obterClientesQuery,
                obterProdutoQuery,
                new CadastrarPedidoValidador(clienteServico, produtoServico));

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(cadastrarPedidoInputSucesso));
        }

        [Test]
        public void CadastrarPedidoProdutoInexistente()
        {
            var freteServiceMock = new FreteServicoMock();
            var freteServico = freteServiceMock.ConfigurarObterFretePeloId().Build();
            var obterFreteQuery = new ObterFreteQuery(freteServico, new ObterFreteValidador(freteServico));

            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloId().ConfigurarObterClientes().Build();
            var obterClientesQuery = new ObterClientesQuery(clienteServico);

            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarObterProdutoPeloIdInexistente().Build();
            var obterProdutoQuery = new ObterProdutosQuery(produtoServico);

            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarPedidoCommand(pedidoServico,
                obterFreteQuery,
                obterClientesQuery,
                obterProdutoQuery,
                new CadastrarPedidoValidador(clienteServico, produtoServico));

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(cadastrarPedidoInputSucesso));
        }
    }
}