using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Servicos
{
    public interface IProdutoServico
    {
        Task<IList<IProduto>> ObterProdutos(CancellationToken cancellationToken);
        Task<IProduto> ObterProdutoPeloId(int id, CancellationToken cancellationToken);
        Task<int> ContarProdutosPorId(int[] ids, CancellationToken cancellationToken);
        Task<int> AtualizarProduto(IProduto Produto, CancellationToken cancellationToken);
        Task<int> CadastrarProduto(IProduto Produto, CancellationToken cancellationToken);
        Task<int> ApagarProduto(int id, CancellationToken cancellationToken);
    }
}
