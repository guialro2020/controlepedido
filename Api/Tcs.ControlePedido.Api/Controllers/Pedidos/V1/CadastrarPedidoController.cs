using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Pedidos;

namespace Tcs.ControlePedido.Api.Controllers.Pedidos.V1
{
    public partial class PedidosController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarTextoPedido([FromBody]CadastrarPedidosInput pedido, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Cadastrando pedido. Json: {JsonConvert.SerializeObject(pedido)}");
            
            var resposta = await this.cadastrarCommand.Executar(pedido, cancellationToken);

            logger.LogInformation($"Pedido cadastrado com sucesso. ID: {resposta.NumeroPedido}");

            return this.Created($"Pedido {resposta.NumeroPedido} inserido com sucesso!", resposta.NumeroPedido);
        }
    }
}