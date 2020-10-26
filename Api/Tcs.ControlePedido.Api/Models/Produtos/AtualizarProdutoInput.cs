using Newtonsoft.Json;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;

namespace Tcs.ControleProduto.Api.Models.Produtos
{
    public class AtualizarProdutoInput : IAtualizarProdutoInput
    {
        [JsonIgnore]
        private int CodigoProduto { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("valorUnitario")]
        public decimal ValorUnitario { get; set; }

        int IAtualizarProdutoInput.CodigoProduto => this.CodigoProduto;

        public AtualizarProdutoInput ConfigurarPatch(int codigoProduto)
        {
            this.CodigoProduto = codigoProduto;

            return this;
        }
    }
}
