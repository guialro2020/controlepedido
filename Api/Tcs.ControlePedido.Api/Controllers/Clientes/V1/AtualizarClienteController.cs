using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Api.Models.Clientes;

namespace Tcs.ControleCliente.Api.Controllers.Clientes.V1
{
    public partial class ClientesController : ControllerBase
    {
        [HttpPatch]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody][Required]AtualizarClientesInput cliente, CancellationToken cancellationToken)
        {
            cliente.ClienteId = id;

            await this.atualizarCommand.Executar(cliente, cancellationToken);

            return this.Ok($"Cliente atualizado com sucesso!");
        }
    }
}