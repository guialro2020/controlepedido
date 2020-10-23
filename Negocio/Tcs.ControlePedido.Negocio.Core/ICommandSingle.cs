using System.Threading;
using System.Threading.Tasks;

namespace Tcs.ControlePedido.Negocio.Core
{
    public interface ICommandSingle<T> where T : ICommandInput
    {
        Task Executar(T input, CancellationToken cancellationToken);
    }
}