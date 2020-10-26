namespace Tcs.ControlePedido.Negocio.Core.Transporte.Commands.CalcularFrete
{
    public interface ICalcularFreteInput : ICommandInput
    {
        int Cep { get; }
    }
}
