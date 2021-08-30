using Application.Interface;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application
{
    public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public virtual void Delete(T obj)
        {
            _serviceBase.Delete(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return _serviceBase.GetAll(predicate);
        }

        public virtual T GetById(object id)
        {
            return _serviceBase.GetById(id);
        }

        public virtual void Insert(T obj)
        {
            _serviceBase.Insert(obj);
        }

        public virtual void Update(T obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
