using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.CadastrarProduto
{
    public class CadastrarProdutoOutput : ICadastrarProdutoOutput
    {
        public int CodigoProduto { get; set; }
    }
}
