using NUnit.Framework;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;

namespace Tcs.ControlePedido.Testes.Clientes
{
    [TestFixture]
    public class ObterClienteTesteUnidade
    {
        [Test]
        public async Task ObterClienteSucesso()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientes().Build();

            var obterQuery = new ObterClientesQuery(clienteServico);

            var resultado = await obterQuery.Executar(null);

            Assert.NotNull(resultado.Clientes);
        }

        [Test]
        public async Task ObterClientePeloIdInexistente()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloIdInexistente().Build();

            var cliente = await clienteServico.ObterClientePeloId(2, default);

            Assert.Zero(cliente.ClienteId);
        }

        [Test]
        public async Task ObterClientePeloIdSucesso()
        {
            var clienteServiceMock = new ClienteServicoMock();
            var clienteServico = clienteServiceMock.ConfigurarObterClientePeloId().Build();

            var cliente = await clienteServico.ObterClientePeloId(1, default);

            Assert.NotNull(cliente);
            Assert.NotZero(cliente.ClienteId);
        }
    }
}