using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface INotaFiscal
    {
        [Key]
        int NotaFiscalId { get; }

        string NomeCompleto { get; }

        string Cpf { get; }

        string Cep { get; }

        int NumeroPedido { get; }

        IEnumerable<IProdutoPedido> ItensPedido { get; }

        string Uf { get; }

        string NomeEstado { get; }

        decimal ValorFrete { get; }
    }
}
