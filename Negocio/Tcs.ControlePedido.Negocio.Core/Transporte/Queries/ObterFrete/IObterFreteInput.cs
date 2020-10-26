namespace Tcs.ControlePedido.Negocio.Core.Transporte.Queries.ObterFrete
{
    public interface IObterFreteInput : IQueryInput
    {
        int Cep { get; }
    }
}
