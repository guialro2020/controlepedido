namespace Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal
{
    public interface IObterNotaFiscalInput : IQueryInput
    {
        int NumeroPedido { get; }
    }
}