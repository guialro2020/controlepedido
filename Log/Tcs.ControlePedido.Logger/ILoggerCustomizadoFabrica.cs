using Microsoft.Extensions.Logging;

namespace Tcs.ControlePedido.Logger
{
    internal interface ILoggerCustomizadoFabrica
    {
        ILogger Criar(TipoLogger tipoLogger,
            string nome,
            ProvedorLogCustomizadoConfiguration loggerConfig);
    }
}
