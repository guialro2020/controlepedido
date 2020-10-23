namespace Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto
{
    public interface ICalcularFreteInput : ICommandInput
    {
        decimal Cep { get; }
    }
}
