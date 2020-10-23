using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarClientes
{
    public class ApagarClienteCommand : IApagarClienteCommand
    {
        private readonly IClienteServico clienteServico;
        private readonly ApagarClienteValidador validador;

        public ApagarClienteCommand(IClienteServico clienteServico,
            ApagarClienteValidador validador)
        {
            this.clienteServico = clienteServico;
            this.validador = validador;
        }

        public async Task Executar(IApagarClienteInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            await this.clienteServico.ApagarCliente(input.ClienteId, cancellationToken);
        }

        private async Task ValidarInput(IApagarClienteInput input, CancellationToken cancellationToken)
        {
            var validacao = await validador.ValidateAsync(input, cancellationToken);

            if (!validacao.IsValid)
            {
                throw new ArgumentException(
                    JsonConvert.SerializeObject(
                        validacao.Errors.Select(f => f.ErrorMessage)));
            }
        }
    }
}
