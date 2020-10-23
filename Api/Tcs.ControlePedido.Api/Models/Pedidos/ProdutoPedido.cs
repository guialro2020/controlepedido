using Newtonsoft.Json;

namespace Tcs.ControlePedido.Api.Models.Pedidos
{
    public class ProdutoPedido
    {
        [JsonProperty("codigoProduto")]
        public int CodigoProduto { get; set; }

        [JsonProperty("valorTotal")]
        public decimal ValorTotal { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }
    }
}