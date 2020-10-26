using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;

namespace Tcs.ControlePedido.Testes.Models.Produtos
{
    public class AtualizarProdutosInput : IAtualizarProdutoInput
    {
        public int CodigoProduto  { get; set; }

        public string Descricao  { get; set; }

        public string Categoria  { get; set; }

        public decimal ValorUnitario  { get; set; }
    }
}
