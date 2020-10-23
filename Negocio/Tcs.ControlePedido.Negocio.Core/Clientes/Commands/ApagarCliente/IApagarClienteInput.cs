namespace Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes
{
    public interface IApagarClienteInput : ICommandInput
    {
        int ClienteId { get; }
    }
}
