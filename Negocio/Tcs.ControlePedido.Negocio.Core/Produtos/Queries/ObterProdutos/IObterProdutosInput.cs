﻿namespace Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos
{
    public interface IObterProdutosInput : IIQueryInput
    {
        int CodigoProduto { get; }
    }
}
