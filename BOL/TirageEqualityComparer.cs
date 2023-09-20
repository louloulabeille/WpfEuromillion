using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    /// <summary>
    /// class qui est pris en compte dans la méthode Contains de la classe TirageRepository
    /// qui va se servir de ce système de comparaison pour comparer 2 objects tirages
    /// </summary>
    public class TirageEqualityComparer : EqualityComparer<Tirage>
    {
        public override bool Equals(Tirage? x, Tirage? y)
        {
            if (x == null || y == null) return false;
            return x.Equals(y);
        }

        public override int GetHashCode([DisallowNull] Tirage obj)
        {
            return obj.GetHashCode();
        }
    }
}
