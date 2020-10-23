using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarCliente;

namespace Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarCliente
{
    public class CadastrarClienteOutput : ICadastrarClienteOutput
    {
        public int ClienteId { get; set; }
    }
}
