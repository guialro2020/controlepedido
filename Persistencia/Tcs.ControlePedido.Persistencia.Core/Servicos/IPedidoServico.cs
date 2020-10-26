using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Servicos
{
    public interface IPedidoServico
    {
        Task<IList<IPedido>> ObterPedidos(CancellationToken cancellationToken);
        Task<IPedido> ObterPedidoPeloId(int id, CancellationToken cancellationToken);
        Task<int> AtualizarPedido(IPedido cliente, CancellationToken cancellationToken = default);
        Task CadastrarPedido(IPedido cliente, CancellationToken cancellationToken = default);
        Task<int> ApagarPedido(int id, CancellationToken cancellationToken);
    }
}
