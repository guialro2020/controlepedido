using FluentValidation;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarCliente;

namespace Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarCliente
{
    public class CadastrarClienteValidador : AbstractValidator<ICadastrarClienteInput>
    {
        public CadastrarClienteValidador()
        {
            RuleFor(f => f.NomeCompleto).NotEmpty().WithMessage("Nome do Cliente não informado");
            RuleFor(f => f.Cpf).NotEmpty().WithMessage("CPF do cliente não informado");
        }
    }
}
