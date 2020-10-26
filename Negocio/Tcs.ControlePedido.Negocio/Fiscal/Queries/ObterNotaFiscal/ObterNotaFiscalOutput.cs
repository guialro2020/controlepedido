using System.Collections.Generic;
using Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Fiscal.Queries.ObterNotaFiscal
{
    internal class ObterNotaFiscalOutput : IObterNotaFiscalOutput
    {
        public string NomeCliente { get; set; }

        public string Cpf { get; set; }

        public int Cep { get; set; }

        public int NumeroPedido { get; set; }

        public IEnumerable<IProdutoPedido> ItensPedido { get; set; }

        public string Uf { get; set; }

        public string NomeEstado { get; set; }

        public decimal ValorFrete { get; set; }
    }
}
