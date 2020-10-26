using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.ApagarProduto;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.ApagarProduto
{
    public class ApagarProdutoValidador : AbstractValidator<IApagarProdutoInput>
    {
        public readonly IProdutoServico produtoServico;

        public ApagarProdutoValidador(IProdutoServico produtoServico)
        {
            this.produtoServico = produtoServico;

            RuleFor(f => f.CodigoProduto).NotEmpty().WithMessage("Código do Produto não informado");
            RuleFor(f => f.CodigoProduto).MustAsync(VerificarExistenciaProduto).WithMessage("O Produto não existe");
        }

        private async Task<bool> VerificarExistenciaProduto(int produtoId, CancellationToken cancellationToken = default)
        {
            var produto = await this.produtoServico.ObterProdutoPeloId(produtoId, cancellationToken);

            return produto != null && produto.CodigoProduto > 0;
        }
    }
}
