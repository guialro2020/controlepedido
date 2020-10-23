using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<int> ApagarProduto(int id)
        {
            this.contexto.Produto.Remove(this.contexto.Produto.Find(id));

            return await this.contexto.SaveChangesAsync();
        }

        public async Task<int> SalvarProduto(IProduto cliente)
        {
            this.contexto.Produto.Update((Produto)cliente);

            return await this.contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<IProduto>> ObterProdutos()
        {
            return await this.contexto.Produto.ToArrayAsync();
        }

        public async Task<IProduto> ObterProdutoPeloId(int id)
        {
            return await this.contexto.Produto.FindAsync(id);
        }
    }
}
