using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Persistencia.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly PersistenciaContexto contexto;

        public ClienteServico(PersistenciaContexto contexto)
        {
            this.contexto = contexto;
        }

        private Cliente PatchCliente(Cliente cliente, ICliente clienteNovo)
        {
            cliente.Bairro = clienteNovo.Bairro;
            cliente.Cep = clienteNovo.Cep;
            cliente.Cidade = clienteNovo.Cidade;
            cliente.Cpf = clienteNovo.Cpf;
            cliente.Endereco = clienteNovo.Endereco;
            cliente.NomeCompleto = clienteNovo.NomeCompleto;
            cliente.Telefone = clienteNovo.Telefone;
            cliente.Uf = clienteNovo.Uf;

            return cliente;
        }

        public async Task<int> ApagarCliente(int id, CancellationToken cancellationToken = default)
        {
            var cliente = await this.contexto.Cliente.FindAsync(new object[] { id }, cancellationToken);

            if (cliente == null)
            {
                throw new ArgumentNullException("O Cliente não foi encontrado");
            }

            this.contexto.Cliente.Remove(cliente);

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> AtualizarCliente(ICliente cliente, CancellationToken cancellationToken = default)
        {
            var clienteLocal = await this.contexto.Cliente.FindAsync(new object[] { cliente.ClienteId }, cancellationToken);

            if (clienteLocal == null)
            {
                throw new ArgumentNullException("O Cliente não foi encontrado");
            }

            this.contexto.Cliente.Update(PatchCliente(clienteLocal, cliente));

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CadastrarCliente(ICliente cliente, CancellationToken cancellationToken = default)
        {
            await this.contexto.Cliente.AddAsync((Cliente)cliente, cancellationToken);

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<ICliente>> ObterClientes(CancellationToken cancellationToken = default)
        {
            return await this.contexto.Cliente.ToArrayAsync(cancellationToken);
        }

        public async Task<ICliente> ObterClientePeloId(int id, CancellationToken cancellationToken = default)
        {
            return await this.contexto.Cliente.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
