using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarCliente;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Clientes;

namespace Tcs.ControlePedido.Testes.Clientes
{
    [TestFixture]
    public class CadastrarClienteTesteUnidade
    {
        [Test]
        public void CadastrarClienteSucesso()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarClienteCommand(clienteServico, new CadastrarClienteValidador());

            Assert.DoesNotThrowAsync(() => cadastrarCommand.Executar(new CadastrarClientesInput
            {
                Bairro = "Dornelas",
                Cep = "32123321",
                Cidade = "Belo Horizonte",
                Cpf = "025321256952",
                Endereco = "Rua Teste",
                NomeCompleto = "Nadal dos Santos",
                Telefone = "33333333",
                Uf = "MG",
            }));
        }

        [Test]
        public void CadastrarClienteErroValidacao()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarClienteCommand(clienteServico, new CadastrarClienteValidador());

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(new CadastrarClientesInput
            {
                Bairro = "Dornelas",
                Cep = "32123321",
                Cidade = "Belo Horizonte",
                Cpf = "025321256952",
                Endereco = "Rua Teste",
                Telefone = "33333333",
                Uf = "MG",
            }));

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(new CadastrarClientesInput
            {
                Bairro = "Dornelas",
                Cep = "32123321",
                Cidade = "Belo Horizonte",
                Endereco = "Rua Teste",
                NomeCompleto = "Nadal dos Santos",
                Telefone = "33333333",
                Uf = "MG",
            }));
        }
    }
}