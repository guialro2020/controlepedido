using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Pedidos;

namespace Tcs.ControlePedido.Api.Controllers.Pedidos.V1
{
    public partial class PedidosController : ControllerBase
    {
        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> RemoverPedido(int id, CancellationToken cancellationToken)
        {
            await this.apagarCommand.Executar(new ApagarPedidosInput
            {
                NumeroPedido = id
            }, cancellationToken);

            return this.Ok($"Pedido {id} removido com sucesso!");
        }
    }
}