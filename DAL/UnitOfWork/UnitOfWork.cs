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
    public class UnitOfWork<T> : IUnitOfWork where T : class
    {
        private readonly EuroDbContest _contest;

        public Repository<T> Entities { get; }

        public UnitOfWork (EuroDbContest context)
        {
            _contest = context;
            Entities = new Repository<T> (context);
        }

        public virtual void Dispose()
        {
            _contest.Dispose();
        }

        public virtual int Save()
        {
            return _contest.SaveChanges();
        }
    }

}
