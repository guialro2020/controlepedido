using System;
using System.Collections.Generic;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.AtualizarPedido
{
    public interface IAtualizarPedidoInput : ICommandInput
    {
        int NumeroPedido { get; }

        DateTime DataPedido { get; }

        int ClienteId { get; }

        IEnumerable<IProdutoPedido> ItensPedido { get; }
    }
}
