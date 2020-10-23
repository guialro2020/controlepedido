using System.ComponentModel.DataAnnotations;

namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface IFrete
    {
        [Key]
        string Uf { get; }

        string NomeEstado { get; }

        int CepInicial { get; }

        int CepFinal { get; }

        decimal ValorFrete { get; }
    }
}