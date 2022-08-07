using Core.Errors;
using Core.Results;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Burada verilen TEntity türü ile bir DBSet oluşturulur -> İlgili tabloya erişim sağlanır
        // DBContext objesi oluşturulur -> DB'ye erişim sağlanır
        private DbSet<T> _entity;
        public TempContext _context;

        public virtual DbSet<T> Entity => _entity ?? _context.Set<T>();

        public GenericRepository(TempContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entity;

        public IQueryable<T> TableNoTracking => Entity.AsNoTracking();

        public void Delete(T entity)
        {
            if (entity == null) throw new NotFoundError();
            
            try
            {
                Entity.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new InternalServerError();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return TableNoTracking.FirstOrDefault(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? TableNoTracking.ToList() : TableNoTracking.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new NotFoundError();
            try
            {
                Entity.Add(entity);
            }
            catch (Exception ex)
            {
                throw new InternalServerError();
            }
        }

        public void Update(T entity)
        {
            if (entity == null) throw new NotFoundError();
            try
            {
                Entity.Update(entity);
            }
            catch (Exception ex)
            {
                throw new InternalServerError();
            }
        }
    }
}
