using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Queries.ObterPedidos;
using Tcs.ControlePedido.Negocio.Core.Transporte.Queries.ObterFrete;

namespace Tcs.ControlePedido.Negocio.Fiscal.Queries.ObterNotaFiscal
{
    public class ObterNotaFiscalQuery : IObterNotaFiscalQuery
    {
        private readonly ObterNotaFiscalValidador obterNotaFiscalValidador;
        private readonly IObterPedidosQuery obterPedidosQuery;
        private readonly IObterClientesQuery obterClientesQuery;
        private readonly IObterFreteQuery calcularFreteQuery;

        public ObterNotaFiscalQuery(ObterNotaFiscalValidador obterNotaFiscalValidador,
            IObterPedidosQuery obterPedidosQuery,
            IObterClientesQuery obterClientesQuery,
            IObterFreteQuery calcularFreteQuery)
        {
            this.obterNotaFiscalValidador = obterNotaFiscalValidador;
            this.obterPedidosQuery = obterPedidosQuery;
            this.obterClientesQuery = obterClientesQuery;
            this.calcularFreteQuery = calcularFreteQuery;
        }

        public async Task<IObterNotaFiscalOutput> Executar(IObterNotaFiscalInput input, CancellationToken cancellationToken)
        {
            await this.obterNotaFiscalValidador.ValidateAsync(input, cancellationToken);

            var obterPedidosInput = new ObterPedidosInput
            {
                NumeroPedido = input.NumeroPedido
            };

            var obterPedidosResultado = await this.obterPedidosQuery.Executar(obterPedidosInput, cancellationToken);
            var pedido = obterPedidosResultado.Pedidos.FirstOrDefault();

            var obterClientesInput = new ObterClientesInput
            {
                ClienteId = pedido.ClienteId
            };

            var obterClientesResultado = await this.obterClientesQuery.Executar(obterClientesInput, cancellationToken);
            var cliente = obterClientesResultado.Clientes.FirstOrDefault();

            var obterFreteInput = new ObterFreteInput
            {
                Cep = cliente.Cep
            };

            var frete = await this.calcularFreteQuery.Executar(obterFreteInput, cancellationToken);

            return new ObterNotaFiscalOutput
            {
                NomeCliente = cliente.NomeCompleto,
                Cep = cliente.Cep,
                Cpf = cliente.Cpf,
                ItensPedido = pedido.ItensPedido,
                NumeroPedido = pedido.NumeroPedido,
                NomeEstado = frete.NomeEstado,
                Uf = frete.Uf,
                ValorFrete = frete.ValorFrete
            };
        }
    }
}
