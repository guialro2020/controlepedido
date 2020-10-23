using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Core.Servicos
{
    public interface IFreteServico
    {
        Task<IFrete> ObterFretePelaUf(string uf, CancellationToken cancellationToken);

        Task<IFrete> ObterFretePeloCep(decimal cep, CancellationToken cancellationToken);
    }
}
