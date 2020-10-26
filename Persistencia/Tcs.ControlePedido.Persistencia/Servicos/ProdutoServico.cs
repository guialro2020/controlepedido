using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Persistencia.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly PersistenciaContexto contexto;

        public ProdutoServico(PersistenciaContexto contexto)
        {
            this.contexto = contexto;
        }

        private Produto PatchProduto(Produto produto, IProduto produtoNovo)
        {
            produto.Categoria = produtoNovo.Categoria;
            produto.CodigoProduto = produtoNovo.CodigoProduto;
            produto.Descricao = produtoNovo.Descricao;
            produto.ValorUnitario = produtoNovo.ValorUnitario;

            return produto;
        }

        public async Task<int> ApagarProduto(int id, CancellationToken cancellationToken = default)
        {
            var produto = await this.contexto.Produto.FindAsync(new object[] { id }, cancellationToken);

            if (produto == null)
            {
                throw new ArgumentNullException("O Produto não foi encontrado");
            }

            this.contexto.Produto.Remove(produto);

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> AtualizarProduto(IProduto produto, CancellationToken cancellationToken = default)
        {
            var produtoLocal = await this.contexto.Produto.FindAsync(new object[] { produto.CodigoProduto }, cancellationToken);

            if (produtoLocal == null)
            {
                throw new ArgumentNullException("O Produto não foi encontrado");
            }

            this.contexto.Produto.Update(PatchProduto(produtoLocal, produto));

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CadastrarProduto(IProduto produto, CancellationToken cancellationToken = default)
        {
            await this.contexto.Produto.AddAsync((Produto)produto, cancellationToken);

            return await this.contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<IProduto>> ObterProdutos(CancellationToken cancellationToken = default)
        {
            return await this.contexto.Produto.ToArrayAsync(cancellationToken);
        }

        public async Task<IProduto> ObterProdutoPeloId(int id, CancellationToken cancellationToken = default)
        {
            return await this.contexto.Produto.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<int> ContarProdutosPorId(int[] id, CancellationToken cancellationToken = default)
        {
            return await this.contexto.Produto.CountAsync(f => id.Any(g => g == f.CodigoProduto), cancellationToken);
        }
    }
}
