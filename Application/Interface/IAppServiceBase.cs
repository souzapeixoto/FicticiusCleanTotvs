using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Interface
{
    public interface IAppServiceBase<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Dispose();
    }
}
