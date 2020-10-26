using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Pedidos.Commands.ApagarPedido;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Pedidos;

namespace Tcs.ControlePedido.Testes.Pedidos
{
    [TestFixture]
    public class ApagarPedidoTesteUnidade
    {
        [Test]
        public void ApagarPedidoNaoEncontrado()
        {
            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarApagarNaoEncontrado().Build();

            var apagarCommand = new ApagarPedidoCommand(pedidoServico, new ApagarPedidoValidador(pedidoServico));

            Assert.ThrowsAsync<ArgumentException>(() => apagarCommand.Executar(new ApagarPedidosInput
            {
                NumeroPedido = 1
            }));
        }

        [Test]
        public void ApagarPedidoSucesso()
        {
            var pedidoServiceMock = new PedidoServicoMock();
            var pedidoServico = pedidoServiceMock.ConfigurarApagarSucesso().Build();

            var apagarCommand = new ApagarPedidoCommand(pedidoServico, new ApagarPedidoValidador(pedidoServico));

            Assert.DoesNotThrowAsync(() => apagarCommand.Executar(new ApagarPedidosInput
            {
                NumeroPedido = 1
            }));
        }
    }
}