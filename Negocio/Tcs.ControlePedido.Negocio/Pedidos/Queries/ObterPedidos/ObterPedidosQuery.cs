using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Queries.ObterPedidos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Queries.ObterPedidos
{
    public class ObterPedidosQuery : IObterPedidosQuery
    {
        private readonly IPedidoServico produtoServico;

        public ObterPedidosQuery(IPedidoServico produtoServico)
        {
            this.produtoServico = produtoServico;
        }
        
        public async Task<IObterPedidosOutput> Executar(IObterPedidosInput input, CancellationToken cancellationToken = default)
        {
            var obterPedidosOutput = new ObterPedidosOutput
            {
                Pedidos = await this.produtoServico.ObterPedidos(cancellationToken)
            };

            return obterPedidosOutput;
        }
    }
}
