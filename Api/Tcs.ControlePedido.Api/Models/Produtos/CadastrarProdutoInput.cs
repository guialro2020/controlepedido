using Newtonsoft.Json;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto;

namespace Tcs.ControleProduto.Api.Models.Produtos
{
    public class CadastrarProdutoInput : ICadastrarProdutoInput
    {
        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("valorUnitario")]
        public decimal ValorUnitario { get; set; }
    }
}
