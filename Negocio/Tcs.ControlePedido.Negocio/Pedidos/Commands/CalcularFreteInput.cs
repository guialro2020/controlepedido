using Tcs.ControlePedido.Negocio.Core.Transporte.Commands.CalcularFrete;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands
{
    public class CalcularFreteInput : ICalcularFreteInput
    {
        public int Cep { get; set; }
    }
}
