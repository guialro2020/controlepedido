using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.ApagarProduto;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto;
using Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos;
using Tcs.ControlePedido.Persistencia;

namespace Tcs.ControleProduto.Api.Controllers.Produtos.V1
{
    [Route("api/v1/produtos")]
    [ApiController]
    public partial class ProdutoController : ControllerBase
    {
        private readonly PersistenciaContexto persistencia;
        private readonly ICadastrarProdutoCommand cadastrarCommand;
        private readonly IAtualizarProdutoCommand atualizarCommand;
        private readonly IApagarProdutoCommand apagarCommand;
        private readonly IObterProdutosQuery query;
        private readonly ILogger<ProdutoController> logger;

        public ProdutoController(ICadastrarProdutoCommand cadastrarCommand,
            IAtualizarProdutoCommand atualizarCommand,
            IApagarProdutoCommand apagarCommand,
            IObterProdutosQuery query,
            PersistenciaContexto persistencia,
            ILogger<ProdutoController> logger)
        {
            this.cadastrarCommand = cadastrarCommand;
            this.atualizarCommand = atualizarCommand;
            this.apagarCommand = apagarCommand;
            this.query = query;
            this.persistencia = persistencia;
            this.logger = logger;
        }
    }
}