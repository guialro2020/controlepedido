using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido
{
    public class CadastrarPedidoCommand : ICadastrarPedidoCommand
    {
        private readonly IPedidoServico pedidoServico;
        private readonly ICalcularFreteCommand calcularFreteCommand;
        private readonly IObterClientesQuery obterClientesQuery;
        private readonly CadastrarPedidoValidador validador;

        public CadastrarPedidoCommand(IPedidoServico pedidoServico,
            ICalcularFreteCommand calcularFreteCommand,
            IObterClientesQuery obterClientesQuery,
            CadastrarPedidoValidador validador)
        {
            this.pedidoServico = pedidoServico;
            this.calcularFreteCommand = calcularFreteCommand;
            this.obterClientesQuery = obterClientesQuery;
            this.validador = validador;
        }

        public async Task<ICadastrarPedidoOutput> Executar(ICadastrarPedidoInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            var pedido = MapearNovoPedido(input);

            pedido.ValorFrete = await ObterValorFrete(input.ClienteId, cancellationToken);

            var cadastrarPedidoOutput = new CadastrarPedidoOutput
            {
                NumeroPedido = await this.pedidoServico.CadastrarPedido(pedido, cancellationToken)
            };

            return cadastrarPedidoOutput;
        }

        private async Task<decimal> ObterValorFrete(int clienteId, CancellationToken cancellationToken)
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

        private async Task<decimal?> ObterCepCliente(int clienteId, CancellationToken cancellationToken)
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
                ItensPedido = input.ItensPedido.Select(f => (ProdutoPedido)f),
                ValorTotal = input.ValorTotal
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
