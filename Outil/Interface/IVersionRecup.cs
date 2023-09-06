using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outil.Interface
{
    internal interface IVersionRecup : IDisposable
    {
        Version Version { get; }
        string GetVersion();
    }
}
