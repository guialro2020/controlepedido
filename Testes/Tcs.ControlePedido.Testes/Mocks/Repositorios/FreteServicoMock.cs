using Moq;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Testes.Mocks.Repositorios
{
    public class FreteServicoMock
    {
        private readonly Mock<IFreteServico> freteServicoMock = new Mock<IFreteServico>();
        
        public FreteServicoMock ConfigurarObterFretePeloId()
        {
            this.freteServicoMock
                .Setup(f => f.ObterFretePeloCep(It.IsAny<int>(), default))
                .Returns(Task.FromResult((IFrete)new Frete
                {
                    FreteId = 1,
                    CepInicial = 00000000,
                    CepFinal = 10000000,
                    NomeEstado = "Teste",
                    Uf = "TS",
                    ValorFrete = 1
                }));

            return this;
        }

        public FreteServicoMock ConfigurarObterFretePeloIdInexistente()
        {
            this.freteServicoMock
                .Setup(f => f.ObterFretePeloCep(It.Is<int>(g => g != 1), default))
                .Returns(Task.FromResult((IFrete)new Frete { }));

            return this;
        }

        public IFreteServico Build()
        {
            return this.freteServicoMock.Object;
        }
    }
}
