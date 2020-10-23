using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.ApagarCliente;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.AtualizarCliente;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarCliente;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Persistencia;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    [Route("api/v1/clientes")]
    [ApiController]
    public partial class ClientesController : ControllerBase
    {
        private readonly PersistenciaContexto persistencia;
        private readonly ICadastrarClienteCommand cadastrarCommand;
        private readonly IAtualizarClienteCommand atualizarCommand;
        private readonly IApagarClienteCommand apagarCommand;
        private readonly IObterClientesQuery query;
        private readonly ILogger<ClientesController> logger;

        public ClientesController(ICadastrarClienteCommand cadastrarCommand,
            IAtualizarClienteCommand atualizarCommand,
            IApagarClienteCommand apagarCommand,
            IObterClientesQuery query,
            PersistenciaContexto persistencia,
            ILogger<ClientesController> logger)
        {
            this.cadastrarCommand = cadastrarCommand;
            this.atualizarCommand = atualizarCommand;
            this.apagarCommand = apagarCommand;
            this.query = query;
            this.persistencia = persistencia;
            this.logger = logger;
        }
    }
}