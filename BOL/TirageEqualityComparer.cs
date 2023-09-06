using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
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
