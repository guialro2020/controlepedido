using System.ComponentModel.DataAnnotations;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Modelos
{
    public class Produto : IProduto
    {
        [Key]
        public int CodigoProduto { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public decimal ValorUnitario { get; set; }
    }
}
