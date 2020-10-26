using Newtonsoft.Json;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Api.Models.Pedidos
{
    public class ProdutoPedido : IProdutoPedido
    {
        [JsonProperty("codigoProduto")]
        public int CodigoProduto { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        int IProdutoPedido.ProdutoPedidoId => 0;

        decimal IProdutoPedido.ValorTotal => 0;
    }
}