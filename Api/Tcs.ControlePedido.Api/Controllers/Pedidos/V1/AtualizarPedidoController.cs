using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody][Required]AtualizarPedidosInput cliente, CancellationToken cancellationToken)
        {
            cliente.NumeroPedido = id;

            await this.atualizarCommand.Executar(cliente, cancellationToken);

            return this.Ok($"Pedido {cliente.NumeroPedido} atualizado com sucesso!");
        }
    }
}