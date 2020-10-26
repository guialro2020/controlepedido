using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.CadastrarProduto
{
    public class CadastrarProdutoCommand : ICadastrarProdutoCommand
    {
        private readonly IProdutoServico clienteServico;
        private readonly CadastrarProdutoValidador validador;

        public CadastrarProdutoCommand(IProdutoServico clienteServico,
            CadastrarProdutoValidador validador)
        {
            this.clienteServico = clienteServico;
            this.validador = validador;
        }

        public async Task<ICadastrarProdutoOutput> Executar(ICadastrarProdutoInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            var produtoNovo = MapearNovoProduto(input);
            await this.clienteServico.CadastrarProduto(produtoNovo, cancellationToken);

            var cadastrarProdutoOutput = new CadastrarProdutoOutput
            {
                CodigoProduto = produtoNovo.CodigoProduto
            };

            return cadastrarProdutoOutput;
        }

        private IProduto MapearNovoProduto(ICadastrarProdutoInput input)
        {
            return new Produto
            {
                Categoria = input.Categoria,
                Descricao = input.Descricao,
                ValorUnitario = input.ValorUnitario
            };
        }

        private async Task ValidarInput(ICadastrarProdutoInput input, CancellationToken cancellationToken)
        {
            var validador = new CadastrarProdutoValidador();
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
