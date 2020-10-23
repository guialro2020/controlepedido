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
        [JsonIgnore]
        public int NumeroPedido { get; set; }

        [JsonProperty("dataPedido")]
        public DateTime DataPedido { get; set; }

        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("valorTotal")]
        public decimal ValorTotal { get; set; }

        [JsonProperty("itensPedido")]
        public IEnumerable<ProdutoPedido> ItensPedido { get; set; }

        IEnumerable<IProdutoPedido> IAtualizarPedidoInput.ItensPedido => this.ItensPedido.Select(f => (IProdutoPedido)f);
    }
}
