using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoValidador : AbstractValidator<IAtualizarProdutoInput>
    {
        public readonly IProdutoServico clienteServico;

        public AtualizarProdutoValidador(IProdutoServico clienteServico)
        {
            this.clienteServico = clienteServico;

            RuleFor(f => f.CodigoProduto).NotEmpty().WithMessage("Código do Produto não informado");
            RuleFor(f => f.CodigoProduto).MustAsync(VerificarExistenciaProduto).WithMessage("O Produto não existe");
        }

        private async Task<bool> VerificarExistenciaProduto(int clienteId, CancellationToken cancellationToken = default)
        {
            var produto = await this.clienteServico.ObterProdutoPeloId(clienteId, cancellationToken);

            return produto != null && produto.CodigoProduto > 0;
        }
    }
}
