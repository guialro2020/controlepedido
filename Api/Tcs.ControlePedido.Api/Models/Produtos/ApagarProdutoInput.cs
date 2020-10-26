using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.ApagarProduto;

namespace Tcs.ControleProduto.Api.Models.Produtos
{
    public class ApagarProdutoInput : IApagarProdutoInput
    {
        public int CodigoProduto { get; set; }
    }
}
