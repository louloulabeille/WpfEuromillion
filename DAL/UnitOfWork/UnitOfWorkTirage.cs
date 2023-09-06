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
    public class UnitOfWorkTirage : UnitOfWork<Tirage>
    {
        public new ITirageRepository Entities;

        public UnitOfWorkTirage(EuroDbContest context) : base(context)
        {
            Entities = new TirageRepository(context);
        }

    }
}
