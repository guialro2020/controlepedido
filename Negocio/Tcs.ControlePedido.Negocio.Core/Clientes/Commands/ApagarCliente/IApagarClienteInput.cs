namespace Tcs.ControlePedido.Negocio.Core.Clientes.Commands.ApagarCliente
{
    public interface IApagarClienteInput : ICommandInput
    {
        int ClienteId { get; }
    }
}
