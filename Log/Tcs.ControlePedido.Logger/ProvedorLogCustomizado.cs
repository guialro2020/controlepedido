using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Tcs.ControlePedido.Logger
{
    public class ProvedorLogCustomizado : ILoggerProvider
    {
        private readonly ProvedorLogCustomizadoConfiguration loggerConfig;
        private ConcurrentDictionary<string, ILogger> loggers =
            new ConcurrentDictionary<string, ILogger>();

        public ProvedorLogCustomizado(ProvedorLogCustomizadoConfiguration loggerConfig)
        {
            this.loggerConfig = loggerConfig;
        }

        public ILogger CreateLogger(string categoryName)
        {
            var loggerCustomizadoFactory = new LoggerCustomizadoFabrica();

            return loggers.GetOrAdd(categoryName, name => loggerCustomizadoFactory.Criar(TipoLogger.Arquivo, name, this.loggerConfig));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}