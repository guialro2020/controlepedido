using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;

namespace Tcs.ControlePedido.Testes.Models.Clientes
{
    public class ApagarClientesInput : IApagarClienteInput
    {
        public int ClienteId { get; set; }
    }
}
