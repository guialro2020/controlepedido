using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tcs.ControlePedido.Persistencia.Core.Modelos;
using Tcs.ControlePedido.Persistencia.Core.Servicos;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Persistencia.Servicos
{
    public class FreteServico : IFreteServico
    {
        private readonly PersistenciaContexto contexto;

        public FreteServico(PersistenciaContexto contexto)
        {
            this.contexto = contexto;

            this.contexto.AddRange(new List<Frete>
            {
                new Frete(1, "AC", "Acre", 69900000, 69999999, 62.75M),
                new Frete(2, "AL", "Alagoas", 57000000, 57999999, 5.21M),
                new Frete(3, "AM", "Amazonas", 69000000, 69299999, 53.74M),
                new Frete(4, "AM", "Amazonas", 69400000, 69899999, 53.74M),
                new Frete(5, "AP", "Amapá", 68900000, 68999999, 44.12M),
                new Frete(6, "BA", "Bahia", 40000000, 48999999, 24.36M),
                new Frete(7, "CE", "Ceará", 60000000, 63999999, 33.52M),
                new Frete(8, "DF", "Brasília", 70000000, 72799999, 19.54M),
                new Frete(9, "DF", "Brasília", 73000000, 73699999, 19.54M),
                new Frete(10, "ES", "Espírito Santo", 29000000, 29999999, 47.96M),
                new Frete(11, "GO", "Goiás", 69300000, 69399999, 19.89M),
                new Frete(12, "GO", "Goiás", 73700000, 76799999, 19.89M),
                new Frete(13, "MA", "Maranhão", 65000000, 65999999, 16.57M),
                new Frete(14, "MG", "Minas Gerais", 30000000, 39999999, 0M),
                new Frete(15, "MS", "Mato Grosso doSul", 79000000, 79999999, 8.95M),
                new Frete(16, "MT", "Mato Grosso", 78000000, 78899999, 14.59M),
                new Frete(17, "PA", "Pará", 66000000, 68899999, 52.41M),
                new Frete(18, "PB", "Paraíba", 58000000, 58999999, 19.84M),
                new Frete(19, "PE", "Pernambuco", 50000000, 56999999, 42.76M),
                new Frete(20, "PI", "Piauí", 64000000, 64999999, 29.65M),
                new Frete(21, "PR", "Paraná", 80000000, 87999999, 24.24M),
                new Frete(22, "RJ", "Rio de Janeiro", 20000000, 28999999, 24.65M),
                new Frete(23, "RN", "Rio Grande do Norte", 59000000, 59999999, 56.77M),
                new Frete(24, "RO", "Rondônia", 76800000, 76999999, 68.48M),
                new Frete(25, "RO", "Rondônia", 78900000, 78999999, 68.48M),
                new Frete(26, "RR", "Roraima", 69300000, 69399999, 57.78M),
                new Frete(27, "RS", "Rio Grande do Sul", 90000000, 99999999, 22.57M),
                new Frete(28, "SC", "Santa Catarina", 88000000, 89999999, 16.45M),
                new Frete(29, "SE", "Sergipe", 49000000, 49999999, 18.98M),
                new Frete(30, "SP", "São Paulo", 01000000, 19999999, 2.00M),
                new Frete(31, "TO", "Tocantins", 77000000, 77999999, 8.59M)
            });
        }

        public async Task<IFrete> ObterFretePelaUf(string uf, CancellationToken cancellationToken)
        {
            return await this.contexto.Frete.FindAsync(new object[] { uf }, cancellationToken);
        }

        public async Task<IFrete> ObterFretePeloCep(decimal cep, CancellationToken cancellationToken)
        {
            return await this.contexto.Frete.FirstOrDefaultAsync(f => f.CepInicial <= cep && f.CepFinal >= cep, cancellationToken);
        }
    }
}
