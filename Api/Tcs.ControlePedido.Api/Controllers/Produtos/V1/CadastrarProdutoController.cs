using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControleProduto.Api.Models.Produtos;

namespace Tcs.ControleProduto.Api.Controllers.Produtos.V1
{
    public partial class ProdutoController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarTextoProduto([FromBody]CadastrarProdutoInput produto, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Cadastrando produto. Json: {JsonConvert.SerializeObject(produto)}");
            
            var resposta = await this.cadastrarCommand.Executar(produto, cancellationToken);

            logger.LogInformation($"Produto cadastrado com sucesso. ID: {resposta.CodigoProduto}");

            return this.Created($"Produto {produto.Descricao} inserido com sucesso!", resposta.CodigoProduto);
        }
    }
}