using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class DTOPrevisaoDeGastos
    {
        public DTOPrevisaoDeGastos()
        {

        }
        public DTOPrevisaoDeGastos(string nome,
            string marca,
            string modelo, 
            int ano, 
            decimal quantidadeDeCombustivelGasto,
            decimal valorTotalGastoComCombustivel)
        {
            this.Nome = nome;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.QuantidadeDeCombustivelGasto = quantidadeDeCombustivelGasto;
            this.ValorTotalGastoComCombustivel = valorTotalGastoComCombustivel;
        }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public decimal QuantidadeDeCombustivelGasto { get; set; }
        public decimal ValorTotalGastoComCombustivel { get; set; }
    }
}
