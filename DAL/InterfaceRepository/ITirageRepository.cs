using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfaceRepository
{
    /// <summary>
    /// interface spécifique pour les Tirages
    /// </summary>
    public interface ITirageRepository : IRepository<Tirage>
    {
        bool TirageExist(Tirage tirage);

    }
}
