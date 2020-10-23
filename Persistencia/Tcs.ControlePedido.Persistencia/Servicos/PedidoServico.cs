using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Persistencia.Servicos
{
    public class PedidoServico : IPedidoServico
    {
        private readonly PersistenciaContexto contexto;

        public PedidoServico(PersistenciaContexto contexto)
        {
            this.contexto = contexto;
        }

        private Pedido PatchPedido(Pedido pedido, IPedido pedidoNovo)
        {
            pedido.ClienteId = pedidoNovo.ClienteId;
            pedido.DataPedido = pedidoNovo.DataPedido;
            pedido.ItensPedido = pedidoNovo.ItensPedido.Select(f => (ProdutoPedido)f);
            pedido.NumeroPedido = pedidoNovo.NumeroPedido;
            pedido.ValorFrete = pedidoNovo.ValorFrete;
            pedido.ValorTotal = pedidoNovo.ValorTotal;

            return pedido;
        }

        public async Task<int> ApagarPedido(int id, CancellationToken cancellationToken = default)
        {
            var pedido = await this.contexto.Pedido.FindAsync(new object[] { id }, cancellationToken);

            if (pedido == null)
            {
                throw new ArgumentNullException("O Pedido não foi encontrado");
            }

            this.contexto.Pedido.Remove(pedido);

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> AtualizarPedido(IPedido pedido, CancellationToken cancellationToken = default)
        {
            var pedidoLocal = await this.contexto.Pedido.FindAsync(new object[] { pedido.NumeroPedido }, cancellationToken);

            if (pedidoLocal == null)
            {
                throw new ArgumentNullException("O Pedido não foi encontrado");
            }

            this.contexto.Pedido.Update(PatchPedido(pedidoLocal, pedido));

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CadastrarPedido(IPedido pedido, CancellationToken cancellationToken = default)
        {
            await this.contexto.Pedido.AddAsync((Pedido)pedido, cancellationToken);

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<IPedido>> ObterPedidos(CancellationToken cancellationToken = default)
        {
            return await this.contexto.Pedido.ToArrayAsync(cancellationToken);
        }

        public async Task<IPedido> ObterPedidoPeloId(int id, CancellationToken cancellationToken = default)
        {
            return await this.contexto.Pedido.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
