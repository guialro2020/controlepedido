using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Pedidos;

namespace Tcs.ControlePedido.Api.Controllers.Pedidos.V1
{
    public partial class PedidosController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarTextoPedido([FromBody]CadastrarPedidosInput cliente, CancellationToken cancellationToken)
        {
            var resposta = await this.cadastrarCommand.Executar(cliente, cancellationToken);

            return this.Created($"Pedido {resposta.NumeroPedido} inserido com sucesso!", resposta.NumeroPedido);
        }
    }
}