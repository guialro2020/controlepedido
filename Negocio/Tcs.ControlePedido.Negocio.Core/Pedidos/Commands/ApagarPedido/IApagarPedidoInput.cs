namespace Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.ApagarPedido
{
    public interface IApagarPedidoInput : ICommandInput
    {
        int NumeroPedido { get; }
    }
}
