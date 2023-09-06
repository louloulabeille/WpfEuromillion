using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outil.Interface
{
    internal interface IVersion<T> where T : class
    {
        string GetVersion(T connexion);
    }
}
