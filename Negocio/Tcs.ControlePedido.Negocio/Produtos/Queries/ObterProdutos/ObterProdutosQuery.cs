using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Negocio.Core.Produtos.Queries.ObterProdutos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;

namespace Tcs.ControlePedido.Negocio.Produtos.Queries.ObterProdutos
{
    public class ObterProdutosQuery : IObterProdutosQuery
    {
        private readonly IProdutoServico produtoServico;

        public ObterProdutosQuery(IProdutoServico produtoServico)
        {
            this.produtoServico = produtoServico;
        }
        
        public async Task<IObterProdutosOutput> Executar(IObterProdutosInput input, CancellationToken cancellationToken = default)
        {
            var obterProdutosOutput = new ObterProdutosOutput
            {
                Produtos = await this.produtoServico.ObterProdutos(cancellationToken)
            };

            return obterProdutosOutput;
        }
    }
}
