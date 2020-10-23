namespace Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes
{
    public interface IObterClientesInput : IIQueryInput
    {
        int ClienteId { get; }
    }
}
