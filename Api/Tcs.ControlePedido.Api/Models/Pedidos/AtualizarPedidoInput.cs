using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.AtualizarPedido;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Api.Models.Pedidos
{
    public class AtualizarPedidosInput : IAtualizarPedidoInput
    {
        private int NumeroPedido { get; set; }

        [JsonProperty("dataPedido")]
        public DateTime DataPedido { get; set; }

        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("itensPedido")]
        public IEnumerable<ProdutoPedido> ItensPedido { get; set; }

        int IAtualizarPedidoInput.NumeroPedido => this.NumeroPedido;

        IEnumerable<IProdutoPedido> IAtualizarPedidoInput.ItensPedido => this.ItensPedido.Select(f => (IProdutoPedido)f);

        public AtualizarPedidosInput ConfigurarPatch(int numeroPedido)
        {
            this.NumeroPedido = numeroPedido;

            return this;
        }
    }
}
