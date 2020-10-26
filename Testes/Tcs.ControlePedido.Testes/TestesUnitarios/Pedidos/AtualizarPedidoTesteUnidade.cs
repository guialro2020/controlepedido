using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Clientes.Queries.ObterClientes;
using Tcs.ControlePedido.Negocio.Pedidos.Commands;
using Tcs.ControlePedido.Negocio.Pedidos.Commands.AtualizarPedido;
using Tcs.ControlePedido.Negocio.Pedidos.Commands.CadastrarPedido;
using Tcs.ControlePedido.Negocio.Produtos.Queries.ObterProdutos;
using Tcs.ControlePedido.Negocio.Transporte.Commands.CalcularFrete;
using Tcs.ControlePedido.Persistencia.Modelos;
using Tcs.ControlePedido.Testes.Mocks.Repositorios;
using Tcs.ControlePedido.Testes.Models.Clientes;

namespace Tcs.ControlePedido.Testes.Pedidos
{
    [TestFixture]
    public class AtualizarPedidoTesteUnidade
    {
    }
}