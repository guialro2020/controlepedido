using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Tcs.ControlePedido.Api.Controllers.Pedidos.V1
{
    public partial class PedidosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterPedidos(CancellationToken cancellationToken)
        {
            var resposta = await this.query.Executar(null, cancellationToken);
            return this.Content(JsonConvert.SerializeObject(resposta.Pedidos));
        }
    }
}