using FluentValidation;
using Tcs.ControlePedido.Negocio.Core.Transporte.Commands.CalcularFrete;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Transporte.Commands.CalcularFrete
{
    public class CalcularFreteValidador : AbstractValidator<ICalcularFreteInput>
    {
        public readonly IFreteServico clienteServico;

        public CalcularFreteValidador(IFreteServico clienteServico)
        {
            this.clienteServico = clienteServico;

            RuleFor(f => f.Cep).NotEmpty().WithMessage("Cep para cálculo do frete não informado");
        }
    }
}
