using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Clientes;

namespace Tests
{
    [TestFixture]
    public class AtualizarClienteTesteUnidade
    {
        [Test]
        public async Task AtualizarClienteNaoEncontrado()
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
        public async Task AtualizarClienteSucesso()
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
        public async Task AtualizarClienteIdClienteNaoInformado()
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