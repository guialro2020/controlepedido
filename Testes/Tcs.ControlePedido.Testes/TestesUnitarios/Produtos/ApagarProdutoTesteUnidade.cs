using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Produtos.Commands.ApagarProduto;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Produtos;

namespace Tcs.ControlePedido.Testes.Produtos
{
    [TestFixture]
    public class ApagarProdutoTesteUnidade
    {
        [Test]
        public void ApagarProdutoNaoEncontrado()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarApagarNaoEncontrado().Build();

            var apagarCommand = new ApagarProdutoCommand(produtoServico, new ApagarProdutoValidador(produtoServico));

            Assert.ThrowsAsync<ArgumentException>(() => apagarCommand.Executar(new ApagarProdutosInput
            {
                CodigoProduto = 1
            }));
        }

        [Test]
        public void ApagarProdutoSucesso()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarApagarSucesso().Build();

            var apagarCommand = new ApagarProdutoCommand(produtoServico, new ApagarProdutoValidador(produtoServico));

            Assert.DoesNotThrowAsync(() => apagarCommand.Executar(new ApagarProdutosInput
            {
                CodigoProduto = 1
            }));
        }
    }
}