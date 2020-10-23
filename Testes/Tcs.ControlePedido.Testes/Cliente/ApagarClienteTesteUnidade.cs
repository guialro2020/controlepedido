using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Clientes;

namespace Tests
{
    [TestFixture]
    public class ApagarClienteTesteUnidade
    {
        [Test]
        public async Task ApagarClienteNaoEncontrado()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarApagarNaoEncontrado().Build();

            var apagarCommand = new ApagarClienteCommand(clienteServico, new ApagarClienteValidador(clienteServico));

            Assert.ThrowsAsync<ArgumentException>(() => apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = 1
            }));
        }

        [Test]
        public async Task ApagarClienteSucesso()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarApagarSucesso().Build();

            var apagarCommand = new ApagarClienteCommand(clienteServico, new ApagarClienteValidador(clienteServico));

            Assert.DoesNotThrowAsync(() => apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = 1
            }));
        }
    }
}