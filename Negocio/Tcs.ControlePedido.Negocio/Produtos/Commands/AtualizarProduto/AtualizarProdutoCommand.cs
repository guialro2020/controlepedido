using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoCommand : IAtualizarProdutoCommand
    {
        private readonly IProdutoServico clienteServico;
        private readonly AtualizarProdutoValidador validador;

        public AtualizarProdutoCommand(IProdutoServico clienteServico,
            AtualizarProdutoValidador validador)
        {
            this.clienteServico = clienteServico;
            this.validador = validador;
        }

        public async Task Executar(IAtualizarProdutoInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            await this.clienteServico.AtualizarProduto(MapearProduto(input), cancellationToken);
        }

        private IProduto MapearProduto(IAtualizarProdutoInput input)
        {
            return new Produto
            {
                CodigoProduto = input.CodigoProduto,
                Categoria = input.Categoria,
                Descricao = input.Descricao,
                ValorUnitario = input.ValorUnitario
            };
        }

        private async Task ValidarInput(IAtualizarProdutoInput input, CancellationToken cancellationToken)
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
