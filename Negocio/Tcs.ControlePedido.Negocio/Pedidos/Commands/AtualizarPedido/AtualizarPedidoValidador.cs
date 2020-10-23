using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.AtualizarPedido;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.AtualizarPedido
{
    public class AtualizarPedidoValidador : AbstractValidator<IAtualizarPedidoInput>
    {
        public readonly IPedidoServico pedidoServico;
        public readonly IClienteServico clienteServico;

        public AtualizarPedidoValidador(IPedidoServico pedidoServico,
            IClienteServico clienteServico)
        {
            this.pedidoServico = pedidoServico;
            this.clienteServico = clienteServico;

            RuleFor(f => f.NumeroPedido).NotEmpty().WithMessage("Número do Pedido não informado");
            RuleFor(f => f.NumeroPedido).MustAsync(VerificarExistenciaPedido).WithMessage("O Pedido não existe");
            RuleFor(f => f.ClienteId).MustAsync(VerificarExistenciaCliente).WithMessage("O Cliente informado no pedido não existe");
        }

        private async Task<bool> VerificarExistenciaPedido(int numeroPedido, CancellationToken cancellationToken = default)
        {
            var pedido = await this.pedidoServico.ObterPedidoPeloId(numeroPedido, cancellationToken);

            return pedido != null && pedido.NumeroPedido > 0;
        }

        private async Task<bool> VerificarExistenciaCliente(int clienteId, CancellationToken cancellationToken = default)
        {
            var cliente = await this.clienteServico.ObterClientePeloId(clienteId, cancellationToken);

            return cliente != null && cliente.ClienteId > 0;
        }
    }
}
