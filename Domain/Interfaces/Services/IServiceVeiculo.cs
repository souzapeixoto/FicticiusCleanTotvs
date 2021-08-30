using Domain.DTOs;
using Domain.DTOs.InputModel;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IServiceVeiculo : IServiceBase<Veiculo>
    {
        IEnumerable<DTOPrevisaoDeGastos> CalculaPrevisaoDeGastos(InputModelPrevisaoDeGastos model);
    }
}
