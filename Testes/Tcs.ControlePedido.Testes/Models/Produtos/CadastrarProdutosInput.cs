using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto;

namespace Tcs.ControlePedido.Testes.Models.Produtos
{
    public class CadastrarProdutosInput : ICadastrarProdutoInput
    {
        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public decimal ValorUnitario { get; set; }
    }
}
