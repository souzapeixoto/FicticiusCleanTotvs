using Domain.DTOs;
using Domain.DTOs.InputModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class ServiceVeiculo : ServiceBase<Veiculo>, IServiceVeiculo
    {
        private readonly IRepositoryVeiculo _repositoryVeiculo;

        public ServiceVeiculo(IRepositoryVeiculo repositoryVeiculo
            ) : base(repositoryVeiculo)
        {
            _repositoryVeiculo = repositoryVeiculo;
        }

        public IEnumerable<DTOPrevisaoDeGastos> CalculaPrevisaoDeGastos(InputModelPrevisaoDeGastos model)
        {
            var veiculos = _repositoryVeiculo.GetAll();
            var listaDeVeiculos = new List<DTOPrevisaoDeGastos>();

            foreach (var veiculo in veiculos)
            {
                var quantidadeCombustivelCidade = model.KmQueSeraPercorridoCidade / veiculo.ConsumoMedioCombustivelNasCidades;
                var quantidadeCombustivelRodovia = model.KmQueSeraPercorridosRodovia / veiculo.ConsumoMedioCombustivelNasRodovias;

                var totalCombustivelGasto = quantidadeCombustivelCidade + quantidadeCombustivelRodovia;
                var valorTotalGasto = totalCombustivelGasto * model.ValorCombustivel;
                listaDeVeiculos.Add(new DTOPrevisaoDeGastos(veiculo.Nome,veiculo.Marca,veiculo.Modelo,veiculo.Ano,Math.Round(totalCombustivelGasto,2), Math.Round(valorTotalGasto,2)));
            }

            
                return listaDeVeiculos.OrderBy(x=>x.ValorTotalGastoComCombustivel);
        }
    }
}
