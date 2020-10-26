using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal;

namespace Tcs.ControlePedido.Api.Controllers.Fiscal.V1
{
    [ApiController]
    [Route("api/v1/notafiscal")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly IObterNotaFiscalQuery obterNotaFiscalQuery;

        public NotaFiscalController(IObterNotaFiscalQuery obterNotaFiscalQuery)
        {
            this.obterNotaFiscalQuery = obterNotaFiscalQuery;
        }

        [HttpGet]
        public async Task<IActionResult> ObterNotaFiscal(int numeroPedido, CancellationToken cancellationToken)
        {
            var notaFiscal = await this.obterNotaFiscalQuery.Executar(new ObterNotaFiscalInput
            {
                NumeroPedido = numeroPedido
            }, cancellationToken);

            return this.Content(JsonConvert.SerializeObject(notaFiscal));
        }
    }
}
