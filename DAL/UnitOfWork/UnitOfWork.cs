using DAL.InterfaceRepository;
using DAL.InterfaceUnitOfWork;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    /// <summary>
    /// implémentation du desing pattern UnitOfWork
    /// implémentation générique
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitOfWork<T> : IUnitOfWork where T : class
    {
        private readonly EuroDbContest _contest;

        public IRepository<T> Entities { get; }

        public UnitOfWork (EuroDbContest context)
        {
            _contest = context;
            Entities = new Repository<T> (context);
        }

        public virtual void Dispose() => GC.SuppressFinalize(this);

        public int Save()
        {
            return _contest.SaveChanges();
        }
    }

}
