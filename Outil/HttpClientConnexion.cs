using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Outil
{
    public class HttpClientConnexion : HttpClient
    {
        public static readonly Uri? Uri;
        public static HttpClientConnexion Instance = new() { BaseAddress = Uri };
        /*private static HttpClientConnexion? _instance;
        private static readonly object _instanceLock = new();

        public static HttpClientConnexion? Instance {  
            get 
            {
                lock (_instanceLock)
                {  
                    _instance ??= new();   
                }
                return _instance; 
            } 
        }*/

    }
}
