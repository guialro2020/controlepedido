using System.ComponentModel.DataAnnotations;
using Tcs.ControlePedido.Persistencia.Core.Modelos;

namespace Tcs.ControlePedido.Persistencia.Modelos
{
    public class Frete : IFrete
    {
        public Frete() { }

        public Frete(int freteId,
            string uf,
            string nomeEstado,
            int cepInicial,
            int cepFinal,
            decimal valorFrete)
        {
            this.FreteId = freteId;
            this.Uf = uf;
            this.NomeEstado = nomeEstado;
            this.CepInicial = cepInicial;
            this.CepFinal = CepFinal;
            this.ValorFrete = valorFrete;
        }

        [Key]
        public int FreteId { get; set; }
        
        public string Uf { get; set; }

        public string NomeEstado { get; set; }

        public int CepInicial { get; set; }

        public int CepFinal { get; set; }

        public decimal ValorFrete { get; set; }
    }
}
