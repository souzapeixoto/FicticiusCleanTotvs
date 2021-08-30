using Domain.DTOs;
using Domain.DTOs.InputModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestFicticiusCleanTotvs.Domain.Services
{
    public class ServiceVeiculoTest
    {
        private Moq.Mock<IRepositoryVeiculo> _repositoryVeiculoMoq;
        private Moq.Mock<IServiceVeiculo> _serviceVeiculoMoq = new Moq.Mock<IServiceVeiculo>();
        private IServiceVeiculo _serviceVeiculo;

        public ServiceVeiculoTest()
        {
            _repositoryVeiculoMoq = new Mock<IRepositoryVeiculo>();
            _serviceVeiculo = new ServiceVeiculo(_repositoryVeiculoMoq.Object);

        }
        [Fact]
        public void CalculaPrevisaoDeGastos()
        {
            var model = new InputModelPrevisaoDeGastos(3.8m, 27.8m, 15.7m);
            var veiculos = GeraVeiculos();
            var previsaoDeGastosOrdemCorreta = new List<DTOPrevisaoDeGastos>();
            var veiculo1 = new DTOPrevisaoDeGastos("Carro 4", "Marca 4", "Modelo 4", 2008, 3.58m, 13.6m);
            var veiculo2 = new DTOPrevisaoDeGastos("Carro 1", "Marca 1", "Modelo 1", 1988, 4.09m, 15.54m);
            var veiculo3 = new DTOPrevisaoDeGastos("Carro 2", "Marca 2", "Modelo 2", 1990, 4.6m, 17.49m);
            var veiculo4 = new DTOPrevisaoDeGastos("Carro 5", "Marca 5", "Modelo 5", 2015, 4.76m, 18.07m);
            var veiculo5 = new DTOPrevisaoDeGastos("Carro 3", "Marca 3", "Modelo 3", 2000, 8.73m, 33.18m);

            previsaoDeGastosOrdemCorreta.Add(veiculo1);
            previsaoDeGastosOrdemCorreta.Add(veiculo2);
            previsaoDeGastosOrdemCorreta.Add(veiculo3);
            previsaoDeGastosOrdemCorreta.Add(veiculo4);
            previsaoDeGastosOrdemCorreta.Add(veiculo5);
            _repositoryVeiculoMoq.Setup(x => x.GetAll()).Returns(veiculos);

            var resposta = _serviceVeiculo.CalculaPrevisaoDeGastos(model).ToList();

            for (var p = 1; p < resposta.Count; p++)
            {
                Assert.True(VerificarElementosDTOPrevisaoDeGastos(resposta[p], previsaoDeGastosOrdemCorreta[p]));
            }

            // Assert.Equal(previsaoDeGastosOrdemCorreta, resposta);
        }

        [Fact]
        public void CalculaPrevisaoDeGastosValoresNegativos()
        {
            var model = new InputModelPrevisaoDeGastos(-10, -15, -50);
            var veiculos = GeraVeiculos();
            _repositoryVeiculoMoq.Setup(x => x.GetAll()).Returns(veiculos);

            var resposta = _serviceVeiculo.CalculaPrevisaoDeGastos(model).ToList();

            foreach (var p in resposta)
            {
                Assert.True(p.QuantidadeDeCombustivelGasto == 0);
                Assert.True(p.ValorTotalGastoComCombustivel == 0);

            }

            // Assert.Equal(previsaoDeGastosOrdemCorreta, resposta);
        }

        [Fact]
        public void CalculaPrevisaoDeGastosPrimeiroElementoValorCombustivel()
        {
            var model = new InputModelPrevisaoDeGastos(3.8m, 27.8m, 15.7m);
            var veiculos = GeraVeiculos();
            var previsaoDeGastosOrdemCorreta = new List<DTOPrevisaoDeGastos>();
            var veiculo1 = new DTOPrevisaoDeGastos("Carro 4", "Marca 4", "Modelo 4", 2008, 3.58m, 13.6m);

            previsaoDeGastosOrdemCorreta.Add(veiculo1);

            _repositoryVeiculoMoq.Setup(x => x.GetAll()).Returns(veiculos);

            var resposta = _serviceVeiculo.CalculaPrevisaoDeGastos(model).ToList();

            Assert.True(resposta.FirstOrDefault().ValorTotalGastoComCombustivel == veiculo1.ValorTotalGastoComCombustivel);

            // Assert.Equal(previsaoDeGastosOrdemCorreta, resposta);
        }

        public List<Veiculo> GeraVeiculos()
        {
            var veiculos = new List<Veiculo>();
            var veiculo1 = new Veiculo("Carro 1", "Marca 1", "Modelo 1", new DateTime(1988, 05, 30), 10, 12);
            var veiculo2 = new Veiculo("Carro 2", "Marca 2", "Modelo 2", new DateTime(1990, 05, 30), 14, 6);
            var veiculo3 = new Veiculo("Carro 3", "Marca 3", "Modelo 3", new DateTime(2000, 05, 30), 3.7m, 12.9m);
            var veiculo4 = new Veiculo("Carro 4", "Marca 4", "Modelo 4", new DateTime(2008, 05, 30), 15, 9.1m);
            var veiculo5 = new Veiculo("Carro 5", "Marca 5", "Modelo 5", new DateTime(2015, 05, 30), 7, 20);

            veiculos.Add(veiculo1);
            veiculos.Add(veiculo2);
            veiculos.Add(veiculo3);
            veiculos.Add(veiculo4);
            veiculos.Add(veiculo5);

            return veiculos;
        }

        public bool VerificarElementosDTOPrevisaoDeGastos(DTOPrevisaoDeGastos el1, DTOPrevisaoDeGastos el2)
        {
            if (el1.Ano == el2.Ano
                && el1.Marca == el2.Marca
                && el1.Modelo == el2.Modelo
                && el1.Nome == el2.Nome
                && el1.QuantidadeDeCombustivelGasto == el2.QuantidadeDeCombustivelGasto
                && el1.ValorTotalGastoComCombustivel == el2.ValorTotalGastoComCombustivel)
            {
                return true;
            }

            return false;
        }
    }
}
