using System.Collections.Generic;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal
{
    public interface IObterNotaFiscalOutput
    {
        string NomeCliente { get; }
        string Cpf { get; }
        int Cep { get; }
        int NumeroPedido { get; }
        IEnumerable<IProdutoPedido> ItensPedido { get; }
        string Uf { get; }
        string NomeEstado { get; }
        decimal ValorFrete { get; }
    }
}