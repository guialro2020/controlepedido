using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.AtualizarCliente;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Clientes.Commands.AtualizarCliente
{
    public class AtualizarClienteValidador : AbstractValidator<IAtualizarClienteInput>
    {
        public readonly IClienteServico clienteServico;

        public AtualizarClienteValidador(IClienteServico clienteServico)
        {
            this.clienteServico = clienteServico;

            RuleFor(f => f.ClienteId).NotEmpty().WithMessage("Id do Cliente não informado");
            RuleFor(f => f.ClienteId).MustAsync(VerificarExistenciaCliente).WithMessage("O Cliente não existe");
        }

        private async Task<bool> VerificarExistenciaCliente(int clienteId, CancellationToken cancellationToken = default)
        {
            var cliente = await this.clienteServico.ObterClientePeloId(clienteId, cancellationToken);

            return cliente != null;
        }
    }
}
