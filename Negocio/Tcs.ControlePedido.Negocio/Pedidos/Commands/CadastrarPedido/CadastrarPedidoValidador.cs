using FluentValidation;
using FluentValidation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido
{
    public class CadastrarPedidoValidador : AbstractValidator<ICadastrarPedidoInput>
    {
        public readonly IClienteServico clienteServico;
        public readonly IProdutoServico produtoServico;

        public CadastrarPedidoValidador(IClienteServico clienteServico,
            IProdutoServico produtoServico)
        {
            this.clienteServico = clienteServico;
            this.produtoServico = produtoServico;

            RuleFor(f => f.DataPedido).NotEmpty().WithMessage("Data do Pedido não informada");
            RuleFor(f => f.ItensPedido).NotEmpty().WithMessage("Nenhum item do pedido foi informado");

            RuleFor(f => f.ClienteId).MustAsync(VerificarExistenciaCliente).WithMessage("O Cliente informado no pedido não existe");

            RuleFor(f => f.ItensPedido).CustomAsync(VerificarExistenciaProdutos);
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
