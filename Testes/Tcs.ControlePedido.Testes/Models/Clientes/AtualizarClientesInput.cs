using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.AtualizarCliente;

namespace Tcs.ControlePedido.Testes.Models.Clientes
{
    public class AtualizarClientesInput : IAtualizarClienteInput
    {
        public int ClienteId { get; set; }

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
