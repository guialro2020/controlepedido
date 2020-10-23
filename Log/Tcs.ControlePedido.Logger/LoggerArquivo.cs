using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Tcs.ControlePedido.Logger
{
    internal class LoggerArquivo : ILogger
    {
        readonly string loggerNome;
        readonly ProvedorLogCustomizadoConfiguration loggerConfig;
        private string caminhoArquivo => Path.Combine(AppContext.BaseDirectory, "tcs.controlepedido.log");

        public LoggerArquivo(string nome, ProvedorLogCustomizadoConfiguration loggerConfig)
        {
            this.loggerNome = nome;
            this.loggerConfig = loggerConfig;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public void Log<TState>(LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            string mensagem = $"{DateTime.Now}: {logLevel.ToString()} - {formatter(state, exception)}";

            using (var streamWriter = new StreamWriter(caminhoArquivo, true))
            {
                streamWriter.WriteLine(mensagem);
                streamWriter.Close();
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return this.loggerConfig.LogLevel == logLevel;
        }
    }
}