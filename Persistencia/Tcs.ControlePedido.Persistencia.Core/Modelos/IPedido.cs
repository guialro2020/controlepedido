using System;
using System.Collections.Generic;

namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface IPedido
    {
        int NumeroPedido { get; }

        DateTime DataPedido { get; }

        decimal ValorTotal { get; }

        decimal ValorFrete { get; }

        IEnumerable<IProdutoPedido> ItensPedido { get; }

        ICliente Cliente { get; }
    }
}
