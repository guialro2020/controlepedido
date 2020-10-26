using Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands
{ 
    public class ObterProdutosInput : IObterProdutosInput
    {
        public int CodigoProduto { get; set; }
    }
}
