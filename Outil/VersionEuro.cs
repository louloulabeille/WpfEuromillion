using Outil.Interface;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace EuroLib
{
    /// <summary>
    /// classe qui se connecte au serveur pour vérifier la version du logiciel
    /// </summary>
    public class VersionEuro : IVersion<HttpClient>
    {
        #region propriété
        /// <summary>
        /// Object de l'URL pour se connecter au serveur Http distant pour la vérification de la version du logiciel
        /// </summary>
        private readonly Uri? _url;
        private readonly Version _version = new(1, 0, 1);  // version par défaut
        /// <summary>
        /// correspond si l'oject est bon
        /// </summary>
        public bool UrlOk = false;
        //private static HttpClient _httpClient = new HttpClient();
        #endregion

        #region Constructeur
        /// <summary>
        /// url est l'url de connexion vers le serveur pour faire la recherche de version
        /// </summary>
        /// <param name="url"></param>
        public VersionEuro(string url) {
            UrlOk = Uri.TryCreate(url, UriKind.Absolute, out _url);
        }
        #endregion

        #region méthode
        private void ConnectionAsync(HttpClient connexion)
        {
            if (_url is null) return;
            try
            {
                string ver = connexion.GetStringAsync(_url).Result;
                if (!string.IsNullOrEmpty(ver))
                {
                    Version newVer = new (ver);
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex);
                connexion.Dispose();
            }
        }

        public string GetVersion(HttpClient connexion)
        {
            ConnectionAsync(connexion);
            return _version.ToString();
        }
        #endregion
    }

}
