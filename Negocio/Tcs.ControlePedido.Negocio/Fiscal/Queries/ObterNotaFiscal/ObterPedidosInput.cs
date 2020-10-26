using Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal;

namespace Tcs.ControlePedido.Negocio.Core.Pedidos.Queries.ObterPedidos
{
    public class ObterPedidosInput : IObterPedidosInput
    {
        public int NumeroPedido { get; set; }
    }
}
