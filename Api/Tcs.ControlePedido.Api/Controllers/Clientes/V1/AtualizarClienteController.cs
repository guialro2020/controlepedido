using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Clientes;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    public partial class ClientesController : ControllerBase
    {
        [HttpPatch]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody][Required]AtualizarClientesInput cliente, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Atualizando cliente {id}. Patch: {JsonConvert.SerializeObject(cliente)}");

            cliente.ConfigurarPatch(id);

            await this.atualizarCommand.Executar(cliente, cancellationToken);

            logger.LogInformation($"Cliente {id} atualizado com sucesso");

            return this.Ok($"Cliente atualizado com sucesso!");
        }
    }
}