using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Clientes.Queries.ObterClientes
{
    public class ObterClientesQuery : IObterClientesQuery
    {
        private readonly IClienteServico clienteServico;

        public ObterClientesQuery(IClienteServico clienteServico)
        {
            this.clienteServico = clienteServico;
        }
        
        public async Task<IObterClientesOutput> Executar(IObterClientesInput input, CancellationToken cancellationToken = default)
        {
            var obterClientesOutput = new ObterClientesOutput
            {
                Clientes = await this.clienteServico.ObterClientes(cancellationToken)
            };

            return obterClientesOutput;
        }
    }
}
