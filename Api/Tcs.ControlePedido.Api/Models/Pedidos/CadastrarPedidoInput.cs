using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Api.Models.Pedidos
{
    public class CadastrarPedidosInput : ICadastrarPedidoInput
    {
        [JsonProperty("dataPedido")]
        public DateTime DataPedido { get; set; }

        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("itensPedido")]
        public IEnumerable<ProdutoPedido> ItensPedido { get; set; }

        IEnumerable<IProdutoPedido> ICadastrarPedidoInput.ItensPedido => this.ItensPedido.Select(f => (IProdutoPedido)f);
    }
}
