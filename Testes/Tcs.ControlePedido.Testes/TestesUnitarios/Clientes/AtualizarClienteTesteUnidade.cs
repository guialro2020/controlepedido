using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Commands.AtualizarCliente;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Clientes;

namespace Tcs.ControlePedido.Testes.Clientes
{
    [TestFixture]
    public class AtualizarClienteTesteUnidade
    {
        [Test]
        public void AtualizarClienteNaoEncontrado()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarAtualizarNaoEncontrado().Build();

            var atualizarCommand = new AtualizarClienteCommand(clienteServico, new AtualizarClienteValidador(clienteServico));

            Assert.ThrowsAsync<ArgumentException>(() => atualizarCommand.Executar(new AtualizarClientesInput
            {
                ClienteId = 1
            }));
        }

        [Test]
        public void AtualizarClienteSucesso()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarAtualizarSucesso().Build();

            var atualizarCommand = new AtualizarClienteCommand(clienteServico, new AtualizarClienteValidador(clienteServico));

            Assert.DoesNotThrowAsync(() => atualizarCommand.Executar(new AtualizarClientesInput
            {
                ClienteId = 1
            }));
        }

        [Test]
        public void AtualizarClienteIdClienteNaoInformado()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarAtualizarSucesso().Build();

            var atualizarCommand = new AtualizarClienteCommand(clienteServico, new AtualizarClienteValidador(clienteServico));

            Assert.ThrowsAsync<ArgumentException>(() => atualizarCommand.Executar(new AtualizarClientesInput
            {
                ClienteId = 0
            }));
        }
    }
}