using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;

namespace Tcs.ControlePedido.Api.Models.Clientes
{
    public class ApagarClientesInput : IApagarClienteInput
    {
        public int ClienteId { get; set; }
    }
}
