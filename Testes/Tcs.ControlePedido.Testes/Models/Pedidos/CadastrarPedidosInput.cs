using System;
using System.Collections.Generic;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Testes.Models.Pedidos
{
    public class CadastrarPedidosInput : ICadastrarPedidoInput
    {
        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }

        public IEnumerable<IProdutoPedido> ItensPedido { get; set; }
    }
}
