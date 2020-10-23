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
    public class CadastrarClienteCommand : ICadastrarClienteCommand
    {
        private readonly IClienteServico clienteServico;
        private readonly CadastrarClienteValidador validador;

        public CadastrarClienteCommand(IClienteServico clienteServico,
            CadastrarClienteValidador validador)
        {
            this.clienteServico = clienteServico;
            this.validador = validador;
        }

        public async Task<ICadastrarClienteOutput> Executar(ICadastrarClienteInput input, CancellationToken cancellationToken = default)
        {
            await ValidarInput(input, cancellationToken);

            var cadastrarClienteOutput = new CadastrarClienteOutput
            {
                ClienteId = await this.clienteServico.CadastrarCliente(MapearNovoCliente(input), cancellationToken)
            };

            return cadastrarClienteOutput;
        }

        private ICliente MapearNovoCliente(ICadastrarClienteInput input)
        {
            return new Cliente
            {
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

        private async Task ValidarInput(ICadastrarClienteInput input, CancellationToken cancellationToken)
        {
            var validador = new CadastrarClienteValidador();
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
