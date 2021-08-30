using Bogus;
using Domain.Entities;
using System.Collections.Generic;

namespace TestFicticiusCleanTotvs.FakerData
{
    public static class VeiculoFaker
    {
        public static IEnumerable<Veiculo> GeraVeiculos(int numOfRegisters)
        {
            var faker = new Faker<Veiculo>().StrictMode(true)
                .RuleFor(x => x.Nome, y => y.Vehicle.Model())
                .RuleFor(x => x.Marca, y => y.Vehicle.Manufacturer())
                .RuleFor(x => x.Modelo, y => y.Vehicle.Type())
                .RuleFor(x => x.DataFabricacao, y => y.Date.SoonOffset())
                .RuleFor(x => x.ConsumoMedioCombustivelNasCidades, y => y.Finance.Amount(3,20))
                .RuleFor(x => x.ConsumoMedioCombustivelNasRodovias, y => y.Finance.Amount(7, 30));
            var veiculos = faker.Generate(numOfRegisters);
            return veiculos;

        }
    }
}
