using Tcs.ControlePedido.Negocio.Core.Transporte.Queries.ObterFrete;

namespace Tcs.ControlePedido.Negocio.Fiscal.Queries.ObterNotaFiscal
{
    internal class ObterFreteInput : IObterFreteInput
    {
        public int Cep { get; set; }
    }
}