using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.ApagarProduto;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.ApagarProduto
{
    public class ApagarProdutoCommand : IApagarProdutoCommand
    {
        private readonly IProdutoServico produtoServico;
        private readonly ApagarProdutoValidador validador;

        public ApagarProdutoCommand(IProdutoServico produtoServico,
            ApagarProdutoValidador validador)
        {
            this.produtoServico = produtoServico;
            this.validador = validador;
        }

        public async Task Executar(IApagarProdutoInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            await this.produtoServico.ApagarProduto(input.CodigoProduto, cancellationToken);
        }

        private async Task ValidarInput(IApagarProdutoInput input, CancellationToken cancellationToken)
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
