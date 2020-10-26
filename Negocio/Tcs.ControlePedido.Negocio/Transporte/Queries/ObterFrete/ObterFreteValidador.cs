using FluentValidation;
using Tcs.ControlePedido.Negocio.Core.Transporte.Queries.ObterFrete;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Transporte.Queries.ObterFrete
{
    public class ObterFreteValidador : AbstractValidator<IObterFreteInput>
    {
        public readonly IFreteServico clienteServico;

        public ObterFreteValidador(IFreteServico clienteServico)
        {
            this.clienteServico = clienteServico;

            RuleFor(f => f.Cep).NotEmpty().WithMessage("Cep para cálculo do frete não informado");
        }
    }
}
