using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Testes.Mocks.Repositorios
{
    public class PedidoServicoMock
    {
        private readonly Mock<IPedidoServico> pedidoServicoMock = new Mock<IPedidoServico>();

        public PedidoServicoMock ConfigurarApagarSucesso()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IPedido)new Pedido { NumeroPedido = 1 }));

            this.pedidoServicoMock
                .Setup(f => f.ApagarPedido(It.IsAny<int>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public PedidoServicoMock ConfigurarApagarNaoEncontrado()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IPedido)new Pedido { }));

            this.pedidoServicoMock
                .Setup(f => f.ApagarPedido(-1, default))
                .Throws(new ArgumentException("O Pedido não foi encontrado"));

            return this;
        }

        public PedidoServicoMock ConfigurarAtualizarSucesso()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IPedido)new Pedido { NumeroPedido = 1 }));

            this.pedidoServicoMock
                .Setup(f => f.AtualizarPedido(It.IsAny<IPedido>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public PedidoServicoMock ConfigurarAtualizarNaoEncontrado()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IPedido)new Pedido { }));

            this.pedidoServicoMock
                .Setup(f => f.AtualizarPedido(It.IsAny<IPedido>(), default))
                .Throws(new ArgumentException("O Pedido não foi encontrado"));

            return this;
        }

        public PedidoServicoMock ConfigurarCadastrarSucesso()
        {
            this.pedidoServicoMock
                .Setup(f => f.CadastrarPedido(It.IsAny<IPedido>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public PedidoServicoMock ConfigurarObterPedidos()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidos(default))
                .Returns(Task.FromResult((IList<IPedido>)new List<IPedido>() {
                    new Pedido {
                        NumeroPedido = 1,
                        DataPedido = DateTime.Now,
                        ClienteId = 1,
                        ItensPedido = new List<ProdutoPedido>
                        {
                            new ProdutoPedido
                            {
                                CodigoProduto = 1,
                                Quantidade = 51
                            },
                            new ProdutoPedido
                            {
                                CodigoProduto = 2,
                                Quantidade = 32
                            }
                        }
                    }
                }));

            return this;
        }

        public PedidoServicoMock ConfigurarObterPedidoPeloId()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidoPeloId(It.Is<int>(g => g == 1), default))
                .Returns(Task.FromResult((IPedido)new Pedido
                {
                    NumeroPedido = 1,
                    DataPedido = DateTime.Now,
                    ClienteId = 1,
                    ItensPedido = new List<ProdutoPedido>
                    {
                        new ProdutoPedido
                        {
                            CodigoProduto = 1,
                            Quantidade = 51
                        },
                        new ProdutoPedido
                        {
                            CodigoProduto = 2,
                            Quantidade = 32
                        }
                    }
                }));

            return this;
        }

        public PedidoServicoMock ConfigurarObterPedidoPeloIdInexistente()
        {
            this.pedidoServicoMock
                .Setup(f => f.ObterPedidoPeloId(It.Is<int>(g => g != 1), default))
                .Returns(Task.FromResult((IPedido)new Pedido { }));

            return this;
        }

        public IPedidoServico Build()
        {
            return this.pedidoServicoMock.Object;
        }
    }
}
