using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Negocio.Clientes.Commands.CadastrarClientes
{
    public class AtualizarClienteCommand : IAtualizarClienteCommand
    {
        private readonly IClienteServico clienteServico;
        private readonly AtualizarClienteValidador validador;

        public AtualizarClienteCommand(IClienteServico clienteServico,
            AtualizarClienteValidador validador)
        {
            this.clienteServico = clienteServico;
            this.validador = validador;
        }

        public async Task Executar(IAtualizarClienteInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            await this.clienteServico.AtualizarCliente(MapearCliente(input), cancellationToken);
        }

        private ICliente MapearCliente(IAtualizarClienteInput input)
        {
            return new Cliente
            {
                ClienteId = input.ClienteId,
                Bairro = input.Bairro,
                Cep = input.Cep,
                Cidade = input.Cidade,
                Cpf = input.Cpf,
                Endereco = input.Endereco,
                NomeCompleto = input.NomeCompleto,
                Telefone = input.Telefone,
                Uf = input.Uf,
            };
        }

        private async Task ValidarInput(IAtualizarClienteInput input, CancellationToken cancellationToken)
        {
            var validacao = await validador.ValidateAsync(input, cancellationToken);

            if (!validacao.IsValid)
            {
                throw new ArgumentException(
                    JsonConvert.SerializeObject(
                        validacao.Errors.Select(f => f.ErrorMessage)));
            }
        }
    }
}
