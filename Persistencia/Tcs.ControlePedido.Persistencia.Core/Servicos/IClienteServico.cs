using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Servicos
{
    public interface IClienteServico
    {
        Task<IList<ICliente>> ObterClientes(CancellationToken cancellationToken);
        Task<ICliente> ObterClientePeloId(int id, CancellationToken cancellationToken);
        Task<int> AtualizarCliente(ICliente cliente, CancellationToken cancellationToken = default);
        Task<int> CadastrarCliente(ICliente cliente, CancellationToken cancellationToken = default);
        Task<int> ApagarCliente(int id, CancellationToken cancellationToken);
    }
}
