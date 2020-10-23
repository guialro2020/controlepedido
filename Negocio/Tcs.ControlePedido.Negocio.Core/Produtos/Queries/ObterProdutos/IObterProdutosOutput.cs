using System.Collections.Generic;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos
{
    public interface IObterProdutosOutput
    {
        IList<IProduto> Produtos { get; }
    }
}
