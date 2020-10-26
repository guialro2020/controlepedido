using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Produtos.Commands.CadastrarProduto;
using Tcs.ControlePedido.Persistencia.Modelos;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Produtos;

namespace Tcs.ControlePedido.Testes.Produtos
{
    [TestFixture]
    public class CadastrarProdutoTesteUnidade
    {
        [Test]
        public void CadastrarProdutoSucesso()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarProdutoCommand(produtoServico, new CadastrarProdutoValidador());

            Assert.DoesNotThrowAsync(() => cadastrarCommand.Executar(new CadastrarProdutosInput
            {
                Descricao = "Caneta",
                Categoria = "Escolar",
                ValorUnitario = 1.52M
            }));
        }

        [Test]
        public void CadastrarProdutoErroValidacao()
        {
            var produtoServiceMock = new ProdutoServicoMock();
            var produtoServico = produtoServiceMock.ConfigurarCadastrarSucesso().Build();

            var cadastrarCommand = new CadastrarProdutoCommand(produtoServico, new CadastrarProdutoValidador());

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(new CadastrarProdutosInput
            {
                Categoria = "Escolar",
                ValorUnitario = 1.52M
            }));

            Assert.ThrowsAsync<ArgumentException>(() => cadastrarCommand.Executar(new CadastrarProdutosInput

            {
                Descricao = "Caneta",
                Categoria = "Escolar",
                ValorUnitario = -1M
            }));
        }
    }
}