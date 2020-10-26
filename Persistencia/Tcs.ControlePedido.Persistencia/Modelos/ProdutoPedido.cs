using System.ComponentModel.DataAnnotations;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Modelos
{
    public class ProdutoPedido : IProdutoPedido
    {
        public ProdutoPedido() { }

        public ProdutoPedido(IProdutoPedido produtoPedido)
        {
            this.ProdutoPedidoId = produtoPedido.ProdutoPedidoId;
            this.CodigoProduto = produtoPedido.CodigoProduto;
            this.Quantidade = produtoPedido.Quantidade;
            this.ValorTotal = produtoPedido.ValorTotal;
        }

        [Key]
        public int ProdutoPedidoId { get; set; }

        public int CodigoProduto { get; set; }

        public decimal ValorTotal { get; set; }

        public int Quantidade { get; set; }
    }
}
