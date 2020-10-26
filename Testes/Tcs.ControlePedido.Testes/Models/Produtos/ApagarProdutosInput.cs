using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.ApagarProduto;

namespace Tcs.ControlePedido.Testes.Models.Produtos
{
    public class ApagarProdutosInput : IApagarProdutoInput
    {
        public int CodigoProduto { get; set; }
    }
}
