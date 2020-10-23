using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;

namespace Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarClientes
{
    public class CadastrarClienteOutput : ICadastrarClienteOutput
    {
        public int ClienteId { get; set; }
    }
}
