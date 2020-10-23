using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Clientes;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Persistencia;

namespace Tcs.ControlePedido.Api.Controllers.Clientes.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
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

        [HttpDelete]
        [Route("apagar")]
        public async Task<IActionResult> ApagarCliente(int id, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Apagando cliente {id}");

            await this.apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = id
            }, cancellationToken);

            return this.Ok($"Cliente removido com sucesso!");
        }

        [HttpPatch]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody][Required]AtualizarClientesInput cliente, CancellationToken cancellationToken)
        {
            cliente.ClienteId = id;

            logger.LogInformation($"Atualizando cliente {id}");

            await this.atualizarCommand.Executar(cliente, cancellationToken);

            return this.Ok($"Cliente atualizado com sucesso!");
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarTextoPedido([FromBody]CadastrarClientesInput cliente, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Cadastrando cliente {cliente?.NomeCompleto}");

            var resposta = await this.cadastrarCommand.Executar(cliente, cancellationToken);

            return this.Created($"Cliente '{cliente.NomeCompleto}' inserido com sucesso com o ID {resposta.ClienteId}!", resposta.ClienteId);
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Obtendo clientes");

            var resposta = await this.query.Executar(null, cancellationToken);
            return this.Content(JsonConvert.SerializeObject(resposta.Clientes));
        }
    }
}