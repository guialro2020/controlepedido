using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.ApagarPedido;

namespace Tcs.ControlePedido.Testes.Models.Pedidos
{
    public class ApagarPedidosInput : IApagarPedidoInput
    {
        public int NumeroPedido { get; set; }
    }
}
