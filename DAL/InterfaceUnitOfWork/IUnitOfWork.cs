using DAL.InterfaceRepository;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfaceUnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
