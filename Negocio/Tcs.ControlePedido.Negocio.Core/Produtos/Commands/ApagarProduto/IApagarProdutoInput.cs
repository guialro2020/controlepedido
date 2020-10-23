namespace Tcs.ControlePedido.Negocio.Core.Produtos.Commands.ApagarProduto
{
    public interface IApagarProdutoInput : ICommandInput
    {
        int CodigoProduto { get; }
    }
}
