using Microsoft.Extensions.Logging;

namespace Tcs.ControlePedido.Logger
{
    public class ProvedorLogCustomizadoConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; }
    }
}