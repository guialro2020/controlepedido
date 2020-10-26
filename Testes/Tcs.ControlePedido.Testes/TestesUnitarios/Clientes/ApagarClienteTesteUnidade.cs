using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Commands.ApagarCliente;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Clientes;

namespace Tcs.ControlePedido.Testes.Clientes
{
    [TestFixture]
    public class ApagarClienteTesteUnidade
    {
        [Test]
        public void ApagarClienteSucesso()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarApagarSucesso().Build();

            var apagarCommand = new ApagarClienteCommand(clienteServico, new ApagarClienteValidador(clienteServico));

            Assert.DoesNotThrowAsync(() => apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = 1
            }));
        }

        [Test]
        public void ApagarClienteNaoEncontrado()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarApagarNaoEncontrado().Build();

            var apagarCommand = new ApagarClienteCommand(clienteServico, new ApagarClienteValidador(clienteServico));

            Assert.ThrowsAsync<ArgumentException>(() => apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = 1
            }));
        }
    }
}