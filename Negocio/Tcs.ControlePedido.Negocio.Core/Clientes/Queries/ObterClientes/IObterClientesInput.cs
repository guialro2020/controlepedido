namespace Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes
{
    public interface IObterClientesInput : IQueryInput
    {
        int ClienteId { get; }
    }
}
