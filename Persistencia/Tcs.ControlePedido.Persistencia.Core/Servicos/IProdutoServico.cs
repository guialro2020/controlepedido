using System.Collections.Generic;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Servicos
{
    public interface IProdutoServico
    {
        Task<IEnumerable<IProduto>> ObterProdutos();
        Task<int> SalvarProduto(IProduto produto);
        Task<int> ApagarProduto(int id);
    }
}
