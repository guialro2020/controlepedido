using FluentValidation;
using FluentValidation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.AtualizarPedido;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.AtualizarPedido
{
    public class AtualizarPedidoValidador : AbstractValidator<IAtualizarPedidoInput>
    {
        public readonly IPedidoServico pedidoServico;
        public readonly IClienteServico clienteServico;
        public readonly IProdutoServico produtoServico;

        public AtualizarPedidoValidador(IPedidoServico pedidoServico,
            IClienteServico clienteServico,
            IProdutoServico produtoServico)
        {
            this.pedidoServico = pedidoServico;
            this.clienteServico = clienteServico;
            this.produtoServico = produtoServico;

            RuleFor(f => f.NumeroPedido).NotEmpty().WithMessage("Número do Pedido não informado");
            RuleFor(f => f.NumeroPedido).MustAsync(VerificarExistenciaPedido).WithMessage("O Pedido não existe");

            When(f => f.ClienteId > 0, () =>
            {
                RuleFor(f => f.ClienteId).MustAsync(VerificarExistenciaCliente).WithMessage("O Cliente informado no pedido não existe");
            });

            When(f => f.ItensPedido != null && f.ItensPedido.Any(), () =>
            {
                RuleFor(f => f.ItensPedido).CustomAsync(VerificarExistenciaProdutos);
            });
        }

        private async Task<bool> VerificarExistenciaPedido(int numeroPedido, CancellationToken cancellationToken = default)
        {
            var pedido = await this.pedidoServico.ObterPedidoPeloId(numeroPedido, cancellationToken);

            return pedido != null && pedido.NumeroPedido > 0;
        }

        private async Task VerificarExistenciaProdutos(IEnumerable<IProdutoPedido> itensPedido, CustomContext contexto, CancellationToken cancellationToken)
        {
            var quantidadeProdutosExistentes = await this.produtoServico.ContarProdutosPorId(itensPedido.Select(f => f.CodigoProduto).ToArray(), cancellationToken);

            if (quantidadeProdutosExistentes < itensPedido.Count())
            {
                contexto.AddFailure("Alguns produtos inseridos não foram encontrados no banco de dados");
            }
        }

        private async Task<bool> VerificarExistenciaCliente(int clienteId, CancellationToken cancellationToken = default)
        {
            var cliente = await this.clienteServico.ObterClientePeloId(clienteId, cancellationToken);

            return cliente != null && cliente.ClienteId > 0;
        }
    }
}
