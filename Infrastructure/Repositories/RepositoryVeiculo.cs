using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using System;

namespace Infrastructure.Repositories
{
    public class RepositoryVeiculo : RepositoryBase<Veiculo>, IRepositoryVeiculo
    {

        public RepositoryVeiculo(ApplicationDbContext context)
            : base(context)
        {
        }

        void IDisposable.Dispose()
        {
            if (Context != null)
            {
                ((IDisposable)Context).Dispose();
            }
        }
    }
}
