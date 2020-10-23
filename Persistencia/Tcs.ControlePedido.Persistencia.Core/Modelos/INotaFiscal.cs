using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface INotaFiscal
    {
        [Key]
        int NotaFiscalId { get; }
        ICliente Cliente { get; }
        IPedido Pedido { get; }
        IFrete Frete { get; }
    }
}
