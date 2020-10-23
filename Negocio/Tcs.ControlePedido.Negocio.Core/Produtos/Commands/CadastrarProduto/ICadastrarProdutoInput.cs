namespace Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto
{
    public interface ICadastrarProdutoInput : ICommandInput
    {
        string Descricao { get; }

        string Categoria { get; }

        decimal ValorUnitario { get; }
    }
}
