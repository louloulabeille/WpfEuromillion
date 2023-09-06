using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfaceRepository
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();

        void Add(T item);
        void Remove(T item);

        void AddRange(IEnumerable<T> items);
        void RemoveRange(IEnumerable<T> items);
    }
}
