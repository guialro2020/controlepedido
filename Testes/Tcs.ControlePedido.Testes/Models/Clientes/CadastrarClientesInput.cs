using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarCliente;

namespace Tcs.ControlePedido.Testes.Models.Clientes
{
    public class CadastrarClientesInput : ICadastrarClienteInput
    {
        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Telefone { get; set; }
    }
}
