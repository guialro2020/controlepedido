using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public class NotaFiscal : INotaFiscal
    {
        [Key]
        public int NotaFiscalId { get; set; }

        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public string Cep { get; set; }

        public int NumeroPedido { get; set; }

        public IEnumerable<ProdutoPedido> ItensPedido { get; set; }

        public string Uf { get; set; }

        public string NomeEstado { get; set; }

        public decimal ValorFrete { get; set; }

        IEnumerable<IProdutoPedido> INotaFiscal.ItensPedido => this.ItensPedido.Select(f => (IProdutoPedido)f);
    }
}
