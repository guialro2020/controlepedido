using System.Collections.Generic;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes
{
    public interface IObterClientesOutput
    {
        IList<ICliente> Clientes { get; }
    }
}
