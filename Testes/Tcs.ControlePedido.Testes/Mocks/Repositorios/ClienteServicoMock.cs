using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Testes.Mocks.Repositorios
{
    public class ClienteServicoMock
    {
        private readonly Mock<IClienteServico> clienteServicoMock = new Mock<IClienteServico>();

        public ClienteServicoMock ConfigurarApagarSucesso()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientePeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((ICliente)new Cliente { ClienteId = 1 }));

            this.clienteServicoMock
                .Setup(f => f.ApagarCliente(It.IsAny<int>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public ClienteServicoMock ConfigurarApagarNaoEncontrado()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientePeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((ICliente)new Cliente { }));

            this.clienteServicoMock
                .Setup(f => f.ApagarCliente(-1, default))
                .Throws(new ArgumentException("O Cliente não foi encontrado"));

            return this;
        }

        public ClienteServicoMock ConfigurarAtualizarSucesso()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientePeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((ICliente)new Cliente { ClienteId = 1 }));

            this.clienteServicoMock
                .Setup(f => f.AtualizarCliente(It.IsAny<ICliente>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public ClienteServicoMock ConfigurarAtualizarNaoEncontrado()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientePeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((ICliente)new Cliente { }));

            this.clienteServicoMock
                .Setup(f => f.AtualizarCliente(It.IsAny<ICliente>(), default))
                .Throws(new ArgumentException("O Cliente não foi encontrado"));

            return this;
        }

        public ClienteServicoMock ConfigurarCadastrarSucesso()
        {
            this.clienteServicoMock
                .Setup(f => f.CadastrarCliente(It.IsAny<ICliente>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public ClienteServicoMock ConfigurarObterClientes()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientes(default))
                .Returns(Task.FromResult((IList<ICliente>)new List<ICliente>() {
                    new Cliente {
                        ClienteId = 1,
                        Bairro = "Dornelas",
                        Cep = "32123321",
                        Cidade = "Belo Horizonte",
                        Cpf = "025321256952",
                        Endereco = "Rua Teste",
                        NomeCompleto = "Nadal dos Santos",
                        Telefone = "33333333",
                        Uf = "MG",
                    },
                    new Cliente {
                        ClienteId = 2,
                        Bairro = "Adusson",
                        Cep = "32123321",
                        Cidade = "Betim",
                        Cpf = "45685262950",
                        Endereco = "Rua Teste",
                        NomeCompleto = "Radrigo Tuleira",
                        Telefone = "55555555",
                        Uf = "MG",
                    }
                }));

            return this;
        }

        public ClienteServicoMock ConfigurarObterClientePeloId()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientePeloId(It.Is<int>(g => g == 1), default))
                .Returns(Task.FromResult((ICliente)new Cliente
                {
                    ClienteId = 1,
                    Bairro = "Dornelas",
                    Cep = "32123321",
                    Cidade = "Belo Horizonte",
                    Cpf = "025321256952",
                    Endereco = "Rua Teste",
                    NomeCompleto = "Nadal dos Santos",
                    Telefone = "33333333",
                    Uf = "MG",
                }));

            return this;
        }

        public ClienteServicoMock ConfigurarObterClientePeloIdInexistente()
        {
            this.clienteServicoMock
                .Setup(f => f.ObterClientePeloId(It.Is<int>(g => g != 1), default))
                .Returns(Task.FromResult((ICliente)new Cliente { }));

            return this;
        }

        public IClienteServico Build()
        {
            return this.clienteServicoMock.Object;
        }
    }
}
