using System.Threading;
using System.Threading.Tasks;

namespace Tcs.ControlePedido.Negocio.Core
{
    public interface ICommand<T, S> where T : ICommandInput
    {
        Task<S> Executar(T input, CancellationToken cancellationToken);
    }
}
