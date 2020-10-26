using NUnit.Framework;
using System;
using Tcs.ControlePedido.Negocio.Produtos.Commands.AtualizarProduto;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Produtos;

namespace Tcs.ControlePedido.Testes.Produtos
{
    [TestFixture]
    public class AtualizarProdutoTesteUnidade
    {
        [Test]
        public void AtualizarProdutoNaoEncontrado()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarAtualizarNaoEncontrado().Build();

            var atualizarCommand = new AtualizarProdutoCommand(produtoServico, new AtualizarProdutoValidador(produtoServico));

            Assert.ThrowsAsync<ArgumentException>(() => atualizarCommand.Executar(new AtualizarProdutosInput
            {
                CodigoProduto = 1
            }));
        }

        [Test]
        public void AtualizarProdutoSucesso()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarAtualizarSucesso().Build();

            var atualizarCommand = new AtualizarProdutoCommand(produtoServico, new AtualizarProdutoValidador(produtoServico));

            Assert.DoesNotThrowAsync(() => atualizarCommand.Executar(new AtualizarProdutosInput
            {
                CodigoProduto = 1
            }));
        }

        [Test]
        public void AtualizarProdutoIdProdutoNaoInformado()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarAtualizarSucesso().Build();

            var atualizarCommand = new AtualizarProdutoCommand(produtoServico, new AtualizarProdutoValidador(produtoServico));

            Assert.ThrowsAsync<ArgumentException>(() => atualizarCommand.Executar(new AtualizarProdutosInput
            {
                CodigoProduto = 0
            }));
        }
    }
}