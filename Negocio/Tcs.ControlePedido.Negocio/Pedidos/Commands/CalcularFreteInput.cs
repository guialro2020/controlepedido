﻿using Tcs.ControlePedido.Negocio.Core.Transporte.Queries.ObterFrete;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands
{
    public class CalcularFreteInput : IObterFreteInput
    {
        public int Cep { get; set; }
    }
}
