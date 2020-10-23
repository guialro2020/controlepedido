using Microsoft.Extensions.Logging;

namespace Tcs.ControlePedido.Logger
{
    internal class LoggerCustomizadoFabrica : ILoggerCustomizadoFabrica
    {
        public ILogger Criar(TipoLogger tipoLogger, 
            string nome, 
            ProvedorLogCustomizadoConfiguration loggerConfig)
        {
            switch (tipoLogger)
            {
                case TipoLogger.Arquivo:
                    return LoggerArquivo.Instance.Configure(nome, loggerConfig);
                default:
                    return LoggerArquivo.Instance.Configure(nome, loggerConfig);
            }
        }
    }
}
