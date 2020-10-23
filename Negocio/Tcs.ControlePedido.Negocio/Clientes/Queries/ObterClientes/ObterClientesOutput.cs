using System.Collections.Generic;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Clientes.Queries.ObterClientes
{
    public class ObterClientesOutput : IObterClientesOutput
    {
        public IList<ICliente> Clientes { get; set; }
    }
}
