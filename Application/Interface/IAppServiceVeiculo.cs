using Domain.DTOs;
using Domain.DTOs.InputModel;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface IAppServiceVeiculo : IAppServiceBase<Veiculo>
    {
        IEnumerable<DTOPrevisaoDeGastos> CalculaPrevisaoDeGastos(InputModelPrevisaoDeGastos model);
    }
}
