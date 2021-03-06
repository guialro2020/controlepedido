﻿using FluentValidation;
using Tcs.ControlePedido.Negocio.Core.Produtos.Commands.CadastrarProduto;

namespace Tcs.ControlePedido.Negocio.Produtos.Commands.CadastrarProduto
{
    public class CadastrarProdutoValidador : AbstractValidator<ICadastrarProdutoInput>
    {
        public CadastrarProdutoValidador()
        {
            RuleFor(f => f.Descricao).NotEmpty().WithMessage("Descrição do Produto não informado");
            RuleFor(f => f.ValorUnitario).GreaterThanOrEqualTo(0).WithMessage("Valor do produto incorreto");
        }
    }
}
