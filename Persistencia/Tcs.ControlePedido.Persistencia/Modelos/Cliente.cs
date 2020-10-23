using System.ComponentModel.DataAnnotations;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Modelos
{
    public class Cliente : ICliente
    {
        public Cliente() { }

        public Cliente(ICliente cliente)
        {
            this.Bairro = cliente.Bairro;
            this.Cep = cliente.Cep;
            this.Cidade = cliente.Cidade;
            this.Cpf = cliente.Cpf;
            this.Endereco = cliente.Endereco;
            this.NomeCompleto = cliente.NomeCompleto;
            this.Telefone = cliente.Telefone;
            this.Uf = cliente.Uf;
        }

        [Key]
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
