using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControleProduto.Api.Models.Produtos;

namespace Tcs.ControleProduto.Api.Controllers.Produtos.V1
{
    public partial class ProdutoController : ControllerBase
    {
        [HttpPatch]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody][Required]AtualizarProdutoInput produto, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Atualizando produto {id}. Patch: {JsonConvert.SerializeObject(produto)}");

            produto.ConfigurarPatch(id);

            await this.atualizarCommand.Executar(produto, cancellationToken);

            logger.LogInformation($"Produto {id} atualizado com sucesso.");

            return this.NoContent();
        }
    }
}