using NUnit.Framework;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Pedidos.Queries.ObterPedidos;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;

namespace Tcs.ControlePedido.Testes.Pedidos
{
    [TestFixture]
    public class ObterPedidosTesteUnidade
    {
        [Test]
        public async Task ObterPedidoSucesso()
        {
            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarObterPedidos().Build();

            var obterQuery = new ObterPedidosQuery(pedidoServico);

            var resultado = await obterQuery.Executar(null);

            Assert.NotNull(resultado.Pedidos);
        }

        [Test]
        public async Task ObterPedidoPeloIdInexistente()
        {
            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarObterPedidoPeloIdInexistente().Build();

            var pedido = await pedidoServico.ObterPedidoPeloId(2, default);

            Assert.Zero(pedido.NumeroPedido);
        }

        [Test]
        public async Task ObterPedidoPeloIdSucesso()
        {
            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarObterPedidoPeloId().Build();

            var pedido = await pedidoServico.ObterPedidoPeloId(1, default);

            Assert.NotNull(pedido);
            Assert.NotZero(pedido.NumeroPedido);
        }
    }
}