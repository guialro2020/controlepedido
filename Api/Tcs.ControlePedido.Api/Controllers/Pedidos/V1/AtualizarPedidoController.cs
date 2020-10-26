using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Pedidos;

namespace Tcs.ControlePedido.Api.Controllers.Pedidos.V1
{
    public partial class PedidosController : ControllerBase
    {
        [HttpPatch]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody][Required]AtualizarPedidosInput pedido, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Atualizando pedido {id}. Patch: {JsonConvert.SerializeObject(pedido)}");

            pedido.ConfigurarPatch(id);

            await this.atualizarCommand.Executar(pedido, cancellationToken);

            logger.LogInformation($"Pedido {id} atualizado com sucesso.");

            return this.NoContent();
        }
    }
}