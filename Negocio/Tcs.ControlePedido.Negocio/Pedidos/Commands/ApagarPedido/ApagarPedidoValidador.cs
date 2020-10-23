using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.ApagarPedido;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.ApagarPedido
{
    public class ApagarPedidoValidador : AbstractValidator<IApagarPedidoInput>
    {
        public readonly IPedidoServico clienteServico;

        public ApagarPedidoValidador(IPedidoServico clienteServico)
        {
            this.clienteServico = clienteServico;

            RuleFor(f => f.NumeroPedido).NotEmpty().WithMessage("Número do Pedido não informado");
            RuleFor(f => f.NumeroPedido).MustAsync(VerificarExistenciaPedido).WithMessage("O Pedido não existe");
        }

        private async Task<bool> VerificarExistenciaPedido(int clienteId, CancellationToken cancellationToken = default)
        {
            var produto = await this.clienteServico.ObterPedidoPeloId(clienteId, cancellationToken);

            return produto != null && produto.NumeroPedido > 0;
        }
    }
}
