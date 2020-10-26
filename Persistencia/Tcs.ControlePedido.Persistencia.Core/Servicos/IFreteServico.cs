using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Servicos
{
    public interface IFreteServico
    {
        Task<IFrete> ObterFretePeloCep(int cep, CancellationToken cancellationToken = default);
    }
}
