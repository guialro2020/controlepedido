using System.Threading;
using System.Threading.Tasks;

namespace Tcs.ControlePedido.Negocio.Core
{
    public interface IQuery<T, S> where T : IQueryInput
    {
        Task<S> Executar(T input, CancellationToken cancellationToken);
    }
}
