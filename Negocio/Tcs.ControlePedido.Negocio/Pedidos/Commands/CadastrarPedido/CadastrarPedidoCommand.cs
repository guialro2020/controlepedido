using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos;
using Tcs.ControlePedido.Negocio.Core.Transporte.Commands.CalcularFrete;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido
{
    public class CadastrarPedidoCommand : ICadastrarPedidoCommand
    {
        private readonly IPedidoServico pedidoServico;
        private readonly ICalcularFreteCommand calcularFreteCommand;
        private readonly IObterClientesQuery obterClientesQuery;
        private readonly IObterProdutosQuery obterProdutosQuery;
        private readonly CadastrarPedidoValidador validador;

        public CadastrarPedidoCommand(IPedidoServico pedidoServico,
            ICalcularFreteCommand calcularFreteCommand,
            IObterClientesQuery obterClientesQuery,
            IObterProdutosQuery obterProdutosQuery,
            CadastrarPedidoValidador validador)
        {
            this.pedidoServico = pedidoServico;
            this.calcularFreteCommand = calcularFreteCommand;
            this.obterClientesQuery = obterClientesQuery;
            this.obterProdutosQuery = obterProdutosQuery;
            this.validador = validador;
        }

        public async Task<ICadastrarPedidoOutput> Executar(ICadastrarPedidoInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            var pedido = MapearNovoPedido(input);

            pedido.ValorFrete = await ObterValorFrete(input.ClienteId, cancellationToken) ?? 0;

            await this.AtualizarValorTotalItensPedido(pedido.ItensPedido, cancellationToken);

            var cadastrarPedidoOutput = new CadastrarPedidoOutput
            {
                NumeroPedido = await this.pedidoServico.CadastrarPedido(pedido, cancellationToken)
            };

            return cadastrarPedidoOutput;
        }

        private async Task AtualizarValorTotalItensPedido(IEnumerable<ProdutoPedido> itensPedido, CancellationToken cancellationToken)
        {
            foreach (var item in itensPedido)
            {
                var produto = await ObterProdutoPeloCodigo(item, cancellationToken);

                item.ValorTotal = produto.ValorUnitario * item.Quantidade;
            }
        }

        private async Task<IProduto> ObterProdutoPeloCodigo(IProdutoPedido item, CancellationToken cancellationToken)
        {
            var produto = await this.obterProdutosQuery.Executar(new ObterProdutosInput
            {
                CodigoProduto = item.CodigoProduto
            }, cancellationToken);

            return produto.Produtos?.FirstOrDefault() ?? new Produto();
        }

        private async Task<decimal?> ObterValorFrete(int clienteId, CancellationToken cancellationToken)
        {
            var cepCliente = await ObterCepCliente(clienteId, cancellationToken);

            if (!cepCliente.HasValue)
            {
                throw new ArgumentException("Não foi possível encontrar o frete para o CEP informado.");
            }

            return await this.calcularFreteCommand.Executar(new CalcularFreteInput
            {
                Cep = cepCliente.Value
            }, cancellationToken);
        }

        private async Task<int?> ObterCepCliente(int clienteId, CancellationToken cancellationToken)
        {
            var result = await this.obterClientesQuery.Executar(new ObterClientesInput
            {
                ClienteId = clienteId
            }, cancellationToken);

            return result.Clientes?.FirstOrDefault()?.Cep;
        }

        private Pedido MapearNovoPedido(ICadastrarPedidoInput input)
        {
            return new Pedido
            {
                ClienteId = input.ClienteId,
                DataPedido = input.DataPedido,
                ItensPedido = input.ItensPedido.Select(f => new ProdutoPedido(f)).ToList()
            };
        }

        private async Task ValidarInput(ICadastrarPedidoInput input, CancellationToken cancellationToken)
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
