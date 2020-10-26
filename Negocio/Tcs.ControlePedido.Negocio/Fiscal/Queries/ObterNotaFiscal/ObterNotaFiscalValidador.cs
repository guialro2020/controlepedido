using FluentValidation;
using Tcs.ControlePedido.Negocio.Core.Fiscal.Queries.ObterNotaFiscal;

namespace Tcs.ControlePedido.Negocio.Fiscal.Queries.ObterNotaFiscal
{
    public class ObterNotaFiscalValidador : AbstractValidator<IObterNotaFiscalInput>
    {
        public ObterNotaFiscalValidador()
        {
            RuleFor(f => f.NumeroPedido).NotEmpty().WithMessage("Número do Pedido não informado para visualização da Nota Fiscal");
        }
    }
}
