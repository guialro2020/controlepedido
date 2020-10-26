using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Clientes;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    public partial class ClientesController : ControllerBase
    {
        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> RemoverCliente(int id, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Removendo o cliente {id}.");

            await this.apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = id
            }, cancellationToken);

            logger.LogInformation($"Cliente {id} removido com sucesso.");

            return this.Ok($"Cliente removido com sucesso!");
        }
    }
}