using System.ComponentModel.DataAnnotations;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Modelos
{
    public class ProdutoPedido : IProdutoPedido
    {
        [Key]
        public int ProdutoPedidoId { get; set; }

        public int CodigoProduto { get; set; }

        public decimal ValorTotal { get; set; }

        public int Quantidade { get; set; }
    }
}
