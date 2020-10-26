using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Transporte.Queries.ObterFrete;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Transporte.Queries.ObterFrete
{
    public class ObterFreteQuery : IObterFreteQuery
    {
        private readonly IFreteServico freteServico;
        private readonly ObterFreteValidador validador;

        public ObterFreteQuery(IFreteServico freteServico,
            ObterFreteValidador validador)
        {
            this.freteServico = freteServico;
            this.validador = validador;
        }

        public async Task<IFrete> Executar(IObterFreteInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            return await this.freteServico.ObterFretePeloCep(input.Cep, cancellationToken);
        }

        private async Task ValidarInput(IObterFreteInput input, CancellationToken cancellationToken)
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
