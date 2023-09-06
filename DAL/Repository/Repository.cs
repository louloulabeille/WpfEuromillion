using DAL.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(DbContext context)
        {
            _entities = context.Set<T>();
        }

        public void Add(T item)
        {
            _entities.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _entities.AddRange(items);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T? GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Remove(T item)
        {
            _entities.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _entities.RemoveRange(items);
        }
    }
}
