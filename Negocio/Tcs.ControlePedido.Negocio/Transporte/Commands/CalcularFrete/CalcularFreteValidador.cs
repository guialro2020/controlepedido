using FluentValidation;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Fretes.Commands.AtualizarFrete
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
