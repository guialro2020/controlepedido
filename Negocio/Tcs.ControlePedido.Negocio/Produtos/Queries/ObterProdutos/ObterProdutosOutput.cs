using System.Collections.Generic;
using Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Produtos.Queries.ObterProdutos
{
    public class ObterProdutosOutput : IObterProdutosOutput
    {
        public IList<IProduto> Produtos { get; set; }
    }
}
