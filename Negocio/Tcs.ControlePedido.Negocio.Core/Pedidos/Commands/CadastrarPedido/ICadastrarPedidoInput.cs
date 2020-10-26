using System;
using System.Collections.Generic;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido
{
    public interface ICadastrarPedidoInput : ICommandInput
    {
        DateTime DataPedido { get; }

        int ClienteId { get; }

        IEnumerable<IProdutoPedido> ItensPedido { get; }
    }
}
