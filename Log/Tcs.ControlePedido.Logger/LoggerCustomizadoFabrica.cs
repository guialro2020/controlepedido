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
                    return new LoggerArquivo(nome, loggerConfig);
                default:
                    return new LoggerArquivo(nome, loggerConfig);
            }
        }
    }
}
