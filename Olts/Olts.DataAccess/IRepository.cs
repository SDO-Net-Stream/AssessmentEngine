using System;
using System.Linq;
using System.Linq.Expressions;

namespace Olts.DataAccess
{
    public interface IRepository<TModel> : IDisposable
        where TModel : class
    {
        IQueryable<TModel> Get(Expression<Func<TModel, Boolean>> predicate);
        IQueryable<TModel> Get();

        TModel Create(TModel model);
        TModel Read(params Object[] keys);
        void Update(TModel model);
        void Delete(TModel model);
    }
}
