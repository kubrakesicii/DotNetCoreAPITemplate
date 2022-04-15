using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
