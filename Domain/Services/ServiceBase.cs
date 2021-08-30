using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repositorio;

        public ServiceBase(IRepositoryBase<T> repositorio)
        {
            this.repositorio = repositorio;
        }
        public virtual void Delete(T obj)
        {
            repositorio.Delete(obj);
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }
        public IEnumerable<T> GetAll()
        {
            return repositorio.GetAll();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return repositorio.GetAll(predicate);
        }
        public T GetById(object id)
        {
            return repositorio.GetById(id);
        }
        public virtual void Insert(T obj)
        {
            repositorio.Insert(obj);
        }
        public virtual void Update(T obj)
        {
            repositorio.Update(obj);
        }
    }
}
