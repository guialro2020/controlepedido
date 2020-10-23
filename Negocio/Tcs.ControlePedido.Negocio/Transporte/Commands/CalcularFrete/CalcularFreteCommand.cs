using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Negocio.Fretes.Commands.AtualizarFrete;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.AtualizarProduto
{
    public class CalcularFreteCommand : ICalcularFreteCommand
    {
        private readonly IFreteServico freteServico;
        private readonly CalcularFreteValidador validador;

        public CalcularFreteCommand(IFreteServico freteServico,
            CalcularFreteValidador validador)
        {
            this.freteServico = freteServico;
            this.validador = validador;
        }

        public async Task<decimal> Executar(ICalcularFreteInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            var frete = await this.freteServico.ObterFretePeloCep(input.Cep, cancellationToken);

            return frete.ValorFrete;
        }

        private async Task ValidarInput(ICalcularFreteInput input, CancellationToken cancellationToken)
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
