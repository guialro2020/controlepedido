using System.Collections.Generic;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Queries.ObterPedidos;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Queries.ObterPedidos
{
    public class ObterPedidosOutput : IObterPedidosOutput
    {
        public IList<IPedido> Pedidos { get; set; }
    }
}
