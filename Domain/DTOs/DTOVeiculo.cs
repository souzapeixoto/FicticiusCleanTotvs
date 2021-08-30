using System;

namespace Domain.DTOs
{
    public class DTOVeiculo
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal ConsumoMedioCombustivelNasCidades { get; set; }
        public decimal ConsumoMedioCombustivelNasRodovias { get; set; }
    }
}
