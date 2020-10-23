using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Pedidos.Commands.ApagarPedido;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands.ApagarPedido
{
    public class ApagarPedidoCommand : IApagarPedidoCommand
    {
        private readonly IPedidoServico produtoServico;
        private readonly ApagarPedidoValidador validador;

        public ApagarPedidoCommand(IPedidoServico produtoServico,
            ApagarPedidoValidador validador)
        {
            this.produtoServico = produtoServico;
            this.validador = validador;
        }

        public async Task Executar(IApagarPedidoInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            await this.produtoServico.ApagarPedido(input.NumeroPedido, cancellationToken);
        }

        private async Task ValidarInput(IApagarPedidoInput input, CancellationToken cancellationToken)
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
