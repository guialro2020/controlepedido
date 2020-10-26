using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    public partial class ClientesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterClientes(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Buscando todos os clientes.");
            
            var resposta = await this.query.Executar(null, cancellationToken);
            return this.Content(JsonConvert.SerializeObject(resposta.Clientes));
        }
    }
}