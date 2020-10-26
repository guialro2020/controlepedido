using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Tcs.ControleProduto.Api.Controllers.Produtos.V1
{
    public partial class ProdutoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterProdutos(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Buscando todos os produtos.");

            var resposta = await this.query.Executar(null, cancellationToken);
            return this.Content(JsonConvert.SerializeObject(resposta.Produtos));
        }
    }
}