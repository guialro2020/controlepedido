namespace Tcs.ControlePedido.Persistencia.Core.Modelos
{
    public interface ICliente
    {
        int ClienteId { get; }

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
