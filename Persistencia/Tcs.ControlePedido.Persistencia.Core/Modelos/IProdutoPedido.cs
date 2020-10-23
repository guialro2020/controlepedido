namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface IProdutoPedido
    {
        int ProdutoPedidoId { get; }

        int CodigoProduto { get; }

        decimal ValorTotal { get; }

        int Quantidade { get; }
    }
}
