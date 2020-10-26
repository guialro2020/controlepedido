using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Testes.Mocks.Repositorios
{
    public class ProdutoServicoMock
    {
        private readonly Mock<IProdutoServico> produtoServicoMock = new Mock<IProdutoServico>();

        public ProdutoServicoMock ConfigurarApagarSucesso()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IProduto)new Produto { CodigoProduto = 1 }));

            this.produtoServicoMock
                .Setup(f => f.ApagarProduto(It.IsAny<int>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public ProdutoServicoMock ConfigurarApagarNaoEncontrado()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IProduto)new Produto { }));

            this.produtoServicoMock
                .Setup(f => f.ApagarProduto(-1, default))
                .Throws(new ArgumentException("O Produto não foi encontrado"));

            return this;
        }

        public ProdutoServicoMock ConfigurarAtualizarSucesso()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IProduto)new Produto { CodigoProduto = 1 }));

            this.produtoServicoMock
                .Setup(f => f.AtualizarProduto(It.IsAny<IProduto>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public ProdutoServicoMock ConfigurarAtualizarNaoEncontrado()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutoPeloId(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IProduto)new Produto { }));

            this.produtoServicoMock
                .Setup(f => f.AtualizarProduto(It.IsAny<IProduto>(), default))
                .Throws(new ArgumentException("O Produto não foi encontrado"));

            return this;
        }

        public ProdutoServicoMock ConfigurarCadastrarSucesso()
        {
            this.produtoServicoMock
                .Setup(f => f.CadastrarProduto(It.IsAny<IProduto>(), default))
                .Returns(Task.FromResult(1));

            return this;
        }

        public ProdutoServicoMock ConfigurarObterProdutos()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutos(default))
                .Returns(Task.FromResult((IList<IProduto>)new List<IProduto>() {
                    new Produto {
                        CodigoProduto = 1,
                        Descricao = "Caneta",
                        Categoria = "Escolar",
                        ValorUnitario = 1.52M
                    },
                    new Produto {
                        CodigoProduto = 2,
                        Descricao = "Lapis",
                        Categoria = "Escolar",
                        ValorUnitario = 0.68M
                    },
                    new Produto {
                        CodigoProduto = 3,
                        Descricao = "Caderno",
                        Categoria = "Escolar",
                        ValorUnitario = 26.52M
                    }
                }));

            return this;
        }

        public ProdutoServicoMock ConfigurarObterProdutoPeloId()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutoPeloId(It.Is<int>(g => g == 1), default))
                .Returns(Task.FromResult((IProduto)new Produto
                {
                    CodigoProduto = 1,
                    Descricao = "Caneta",
                    Categoria = "Escolar",
                    ValorUnitario = 1.52M
                }));

            return this;
        }

        public ProdutoServicoMock ConfigurarContarProdutosPorId()
        {
            this.produtoServicoMock
                .Setup(f => f.ContarProdutosPorId(It.IsAny<int[]>(), default))
                .Returns(Task.FromResult(2));

            return this;
        }

        public ProdutoServicoMock ConfigurarObterProdutoPeloIdInexistente()
        {
            this.produtoServicoMock
                .Setup(f => f.ObterProdutoPeloId(It.Is<int>(g => g != 1), default))
                .Returns(Task.FromResult((IProduto)new Produto { }));

            return this;
        }

        public IProdutoServico Build()
        {
            return this.produtoServicoMock.Object;
        }
    }
}
