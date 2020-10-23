using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Clientes;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    public partial class ClientesController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarTextoCliente([FromBody]CadastrarClientesInput cliente, CancellationToken cancellationToken)
        {
            var resposta = await this.cadastrarCommand.Executar(cliente, cancellationToken);

            return this.Created($"Cliente '{cliente.NomeCompleto}' inserido com sucesso com o ID {resposta.ClienteId}!", resposta.ClienteId);
        }
    }
}