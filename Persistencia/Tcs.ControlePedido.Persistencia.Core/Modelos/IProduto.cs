namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface IProduto
    {
        int CodigoProduto { get; }

        string Descricao { get; }

        string Categoria { get; }

        decimal ValorUnitario { get; }
    }
}