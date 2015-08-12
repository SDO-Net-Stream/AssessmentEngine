using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Olts.DataAccess
{
    public class DbRepository<TModel> : IRepository<TModel>
        where TModel : class
    {
        // TODO: [Inject]
        public DbRepository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context
        {
            get
            {
                IsObjectDisposed();
                return _context;
            }
        }

        protected IDbSet<TModel> Set
        {
            get
            {
                IsObjectDisposed();
                return _set ?? (_set = Context.Set<TModel>());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public IQueryable<TModel> Get(Expression<Func<TModel, Boolean>> predicate)
        {
            return Set.Where(predicate);
        }

        public IQueryable<TModel> Get()
        {
            return Set.AsQueryable();
        }

        public virtual TModel Create(TModel model)
        {
            IsObjectDisposed();
            DbEntityEntry<TModel> entry = Context.Entry(model);
            entry.State = EntityState.Added;
            Context.SaveChanges();
            entry.State = EntityState.Detached;
            return entry.Entity;
        }

        public virtual TModel Read(params Object[] keys)
        {
            IsObjectDisposed();
            TModel model = Set.Find(keys);
            if (model == null)
            {
                return null;
            }
            var entry = Context.Entry(model);
            entry.State = EntityState.Detached;   
            
            return entry.Entity;
        }

        public virtual void Update(TModel model)
        {
            IsObjectDisposed();
            DbEntityEntry<TModel> entry = Context.Entry(model);
            entry.State = EntityState.Modified;
            Context.SaveChanges();
        }
        
        public void Delete(TModel entity)
        {
            IsObjectDisposed();                        
            DbEntityEntry<TModel> entry = Context.Entry(entity);
            //if (entry.State == EntityState.Detached && entity is IEntity)
            //{
            //    var model = entity as IEntity;
            //    var attachedModel = Set.Find(model.Id);
            //    entry = Context.Entry(attachedModel);
            //}
            entry.State = EntityState.Deleted;
            Context.SaveChanges();
        }
        
        protected virtual void Dispose(Boolean disposing)
        {
            if (_isDisposed || !disposing)
            {
                return;
            }
            if (Context != null)
            {
                Context.Dispose();
            }
            _isDisposed = true;
        }
        
        ~DbRepository()
        {
            Dispose(false);
        }

        private void IsObjectDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            } 
        }

        private readonly DbContext _context;
        private Boolean _isDisposed;
        private IDbSet<TModel> _set;        
    }
}
