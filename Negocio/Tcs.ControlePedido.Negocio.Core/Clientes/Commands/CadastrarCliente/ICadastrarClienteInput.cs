namespace Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes
{
    public interface ICadastrarClienteInput : ICommandInput
    {
        string NomeCompleto { get; }

        string Cpf { get; }

        string Endereco { get; }

        string Cep { get; }

        string Bairro { get; }

        string Cidade { get; }

        string Uf { get; }

        string Telefone { get; }
    }
}
