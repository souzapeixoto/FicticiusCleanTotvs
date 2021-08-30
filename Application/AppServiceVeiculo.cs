using Application.Interface;
using Domain.DTOs;
using Domain.DTOs.InputModel;
using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class AppServiceVeiculo : AppServiceBase<Veiculo>, IAppServiceVeiculo
    {
        private readonly IServiceVeiculo _serviceVeiculo;
        public AppServiceVeiculo(IServiceVeiculo serviceVeiculo)
            : base(serviceVeiculo)
        {
            _serviceVeiculo = serviceVeiculo;
        }

        public IEnumerable<DTOPrevisaoDeGastos> CalculaPrevisaoDeGastos(InputModelPrevisaoDeGastos model)
        {
            return _serviceVeiculo.CalculaPrevisaoDeGastos(model);
        }
    }
}
