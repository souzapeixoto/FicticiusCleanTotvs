using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Veiculo
    {

        public Veiculo()
        {

        }
        public Veiculo(string nome,
            string marca,
            string modelo,
            DateTime dataFabricacao,
            decimal consumoMedioCombustivelNasCidades,
            decimal consumoMedioCombustivelNasRodovias)
        {
            this.Nome = nome;
            this.Marca = marca;
            this.Modelo = modelo;
            this.DataFabricacao = dataFabricacao;
            this.ConsumoMedioCombustivelNasCidades = consumoMedioCombustivelNasCidades;
            this.ConsumoMedioCombustivelNasRodovias = consumoMedioCombustivelNasRodovias;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal ConsumoMedioCombustivelNasCidades { get; set; }
        public decimal ConsumoMedioCombustivelNasRodovias { get; set; }
        public int Ano { get { return this.DataFabricacao.Year; } }
    }
}
