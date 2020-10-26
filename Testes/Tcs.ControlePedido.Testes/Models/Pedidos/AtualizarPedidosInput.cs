using System;
using System.Collections.Generic;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.AtualizarPedido;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Testes.Models.Pedidos
{
    public class AtualizarPedidosInput : IAtualizarPedidoInput
    {
        public int NumeroPedido { get; set; }

        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }

        public IEnumerable<IProdutoPedido> ItensPedido { get; set; }
    }
}
