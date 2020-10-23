using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Clientes;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    public partial class ClientesController : ControllerBase
    {
        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> RemoverCliente(int id, CancellationToken cancellationToken)
        {
            await this.apagarCommand.Executar(new ApagarClientesInput
            {
                ClienteId = id
            }, cancellationToken);

            return this.Ok($"Cliente removido com sucesso!");
        }
    }
}