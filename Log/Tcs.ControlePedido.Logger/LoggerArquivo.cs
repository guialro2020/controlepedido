using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Tcs.ControlePedido.Logger
{
    internal class LoggerArquivo : ILogger
    {
        private string loggerNome;
        private ProvedorLogCustomizadoConfiguration loggerConfig;
        private string caminhoArquivo => Path.Combine(AppContext.BaseDirectory, "tcs.controlepedido.log");
        private readonly object _lock = new object();

        private static LoggerArquivo instance;
        public static LoggerArquivo Instance
        {
            get
            {
                return instance ?? (instance = new LoggerArquivo());
            }
        }

        public LoggerArquivo Configure(string nome, ProvedorLogCustomizadoConfiguration loggerConfig)
        {
            this.loggerNome = nome;
            this.loggerConfig = loggerConfig;

            return this;
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

            lock (_lock)
            {
                using (var streamWriter = new StreamWriter(caminhoArquivo, true))
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return this.loggerConfig.LogLevel == logLevel;
        }
    }
}