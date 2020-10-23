using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands
{
    public class ObterClientesInput : IObterClientesInput
    {
        public int ClienteId { get; set; }
    }
}
