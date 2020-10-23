namespace Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto
{
    public interface IAtualizarProdutoInput : ICommandInput
    {
        int CodigoProduto { get; }

        string Descricao { get; }

        string Categoria { get; }

        decimal ValorUnitario { get; }
    }
}
