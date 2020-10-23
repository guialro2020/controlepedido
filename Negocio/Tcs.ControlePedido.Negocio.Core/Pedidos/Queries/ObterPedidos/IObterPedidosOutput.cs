using System.Collections.Generic;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Core.Pedidos.Queries.ObterPedidos
{
    public interface IObterPedidosOutput
    {
        IList<IPedido> Pedidos { get; }
    }
}
