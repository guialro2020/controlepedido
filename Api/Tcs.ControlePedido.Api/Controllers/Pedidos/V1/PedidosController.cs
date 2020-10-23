using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.ApagarPedido;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.AtualizarPedido;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Queries.ObterPedidos;
using Tcs.ControlePedido.Persistencia;

namespace Tcs.ControlePedido.Api.Controllers.Pedidos.V1
{
    [Route("api/v1/pedidos")]
    [ApiController]
    public partial class PedidosController : ControllerBase
    {
        private readonly PersistenciaContexto persistencia;
        private readonly ICadastrarPedidoCommand cadastrarCommand;
        private readonly IAtualizarPedidoCommand atualizarCommand;
        private readonly IApagarPedidoCommand apagarCommand;
        private readonly IObterPedidosQuery query;
        private readonly ILogger<PedidosController> logger;

        public PedidosController(ICadastrarPedidoCommand cadastrarCommand,
            IAtualizarPedidoCommand atualizarCommand,
            IApagarPedidoCommand apagarCommand,
            IObterPedidosQuery query,
            PersistenciaContexto persistencia,
            ILogger<PedidosController> logger)
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