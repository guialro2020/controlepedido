using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido
{
    public class CadastrarPedidoValidador : AbstractValidator<ICadastrarPedidoInput>
    {
        public readonly IClienteServico clienteServico;

        public CadastrarPedidoValidador(IClienteServico clienteServico)
        {
            this.clienteServico = clienteServico;

            RuleFor(f => f.DataPedido).NotEmpty().WithMessage("Data do Pedido não informada");
            RuleFor(f => f.ValorTotal).NotNull().WithMessage("Valor total do Pedido não informado");

            RuleFor(f => f.ClienteId).MustAsync(VerificarExistenciaCliente).WithMessage("O Cliente informado no pedido não existe");
        }

        private async Task<bool> VerificarExistenciaCliente(int clienteId, CancellationToken cancellationToken = default)
        {
            var cliente = await this.clienteServico.ObterClientePeloId(clienteId, cancellationToken);

            return cliente != null && cliente.ClienteId > 0;
        }
    }
}
