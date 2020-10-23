using System;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.AtualizarProduto;

namespace Tcs.ControlePedido.Negocio.Pedidos.Commands
{
    public class CalcularFreteInput : ICalcularFreteInput
    {
        public decimal Cep { get; set; }
    }
}
