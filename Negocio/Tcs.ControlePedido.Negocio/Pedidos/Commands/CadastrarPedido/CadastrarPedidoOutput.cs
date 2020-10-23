using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido
{
    public class CadastrarPedidoOutput : ICadastrarPedidoOutput
    {
        public int NumeroPedido { get; set; }
    }
}
