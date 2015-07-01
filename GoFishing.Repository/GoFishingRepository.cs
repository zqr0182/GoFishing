using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoFishing.Domain;

namespace GoFishing.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> MatcheAll();
        void Add(T newEntity);
        void Remove(T entity);
    }

    public class GoFishingRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> _dbSet;
        protected GoFishingContext _context;

        public GoFishingRepository(GoFishingContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> MatcheAll()
        {
            return _dbSet;
        }
       
        public void Add(T newEntity)
        {
            _dbSet.Add(newEntity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

    }
}

