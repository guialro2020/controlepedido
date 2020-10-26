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
            pedido.NumeroPedido = pedidoNovo.NumeroPedido;

            if (pedidoNovo.ClienteId > 0)
            {
                pedido.ClienteId = pedidoNovo.ClienteId;
            }

            if (pedidoNovo.DataPedido > DateTime.MinValue)
            {
                pedido.DataPedido = pedidoNovo.DataPedido;
            }

            if (pedidoNovo.ItensPedido != null && pedidoNovo.ItensPedido.Any())
            {
                pedido.ItensPedido = pedidoNovo.ItensPedido.Select(f => (ProdutoPedido)f).ToList();
            }

            if (pedidoNovo.ValorFrete > 0)
            {
                pedido.ValorFrete = pedidoNovo.ValorFrete;
            }

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
            return await this.contexto.Pedido.Include(f => f.ItensPedido).ToArrayAsync(cancellationToken);
        }

        public async Task<IPedido> ObterPedidoPeloId(int id, CancellationToken cancellationToken = default)
        {
            return await this.contexto.Pedido.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
