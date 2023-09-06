using BOL;
using DAL.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TirageRepository : Repository<Tirage>, ITirageRepository
    {
        private readonly EuroDbContest _dbContext;

        public TirageRepository(EuroDbContest context) : base(context)
        {
            _dbContext = context;
        }

        public bool TirageExist(Tirage tirage)
        {
            if (string.IsNullOrEmpty(tirage.Ecroissant) || string.IsNullOrEmpty(tirage.Tcroissant))
            {
                tirage.Ecroissant = string.Empty;
                tirage.Tcroissant = string.Empty;

                int[] tirages = TriPairImpaire.TriDesc(new int[5]
                {
                    tirage.Boule1,
                    tirage.Boule2,
                    tirage.Boule3,
                    tirage.Boule4,
                    tirage.Boule5,
                });

                int[] etoiles = TriPairImpaire.TriAsc(new int[2] {
                    tirage.Etoile1,
                    tirage.Etoile2,
                });           
                
                tirage.Tcroissant = string.Join("-", tirages);
                tirage.Ecroissant = string.Join("-", etoiles);
                
            }
            /*var t = _dbContext.Tirages.ToList<Tirage>();
            t.ToDic_dbContext.Tirages.ToDictionary<int, Tirage>(p => p.Id)*/
            return _dbContext.Tirages.Contains<Tirage>(tirage);
        }

    }
}
