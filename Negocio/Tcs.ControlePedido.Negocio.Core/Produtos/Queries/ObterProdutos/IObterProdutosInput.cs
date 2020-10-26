namespace Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos
{
    public interface IObterProdutosInput : IQueryInput
    {
        int CodigoProduto { get; }
    }
}
