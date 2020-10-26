using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControleProduto.Api.Models.Produtos;

namespace Tcs.ControleProduto.Api.Controllers.Produtos.V1
{
    public partial class ProdutoController : ControllerBase
    {
        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> RemoverProduto(int id, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Removendo o produto {id}.");

            await this.apagarCommand.Executar(new ApagarProdutoInput
            {
                CodigoProduto = id
            }, cancellationToken);

            logger.LogInformation($"Produto {id} removido com sucesso.");

            return this.Ok($"Produto removido com sucesso!");
        }
    }
}