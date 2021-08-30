using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryVeiculo : IRepositoryBase<Veiculo>, IDisposable
    {
    }
}
