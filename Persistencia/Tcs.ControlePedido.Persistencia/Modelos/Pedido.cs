using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Modelos
{
    public class Pedido : IPedido
    {
        [Key]
        public int NumeroPedido { get; set; }

        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }

        public decimal ValorTotal => this.ItensPedido?.Sum(f => f.ValorTotal) ?? 0;

        public decimal ValorFrete { get; set; }

        public List<ProdutoPedido> ItensPedido { get; set; }

        IEnumerable<IProdutoPedido> IPedido.ItensPedido => this.ItensPedido.Select(f => (IProdutoPedido)f).ToList();
    }
}
