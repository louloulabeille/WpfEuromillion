using Outil.Interface;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace EuroLib
{
    /// <summary>
    /// classe qui se connecte au serveur pour v�rifier la version du logiciel
    /// </summary>
    public class VersionEuro : IVersionRecup
    {
        #region propri�t�
        /// <summary>
        /// Object de l'URL pour se connecter au serveur Http distant pour la v�rification de la version du logiciel
        /// </summary>
        private readonly Uri? _url;
        /// <summary>
        /// correspond si l'oject est bon
        /// </summary>
        public bool UrlOk = false;
        public bool ConnexionOk = false;
        public Version Version { get; }

        private readonly HttpClient _httpClient = new();

        #endregion

        #region Constructeur
        /// <summary>
        /// url est l'url de connexion vers le serveur pour faire la recherche de version
        /// </summary>
        /// <param name="url"></param>
        public VersionEuro(string url)
        {
            UrlOk = Uri.TryCreate(url, UriKind.Absolute, out _url);
            Version = ConnectionAsync() ?? new Version(1,0,0);
        }
        #endregion

        #region m�thode
        private Version? ConnectionAsync()
        {
            if (_url is null) return null;
            try
            {
                string ver = _httpClient.GetStringAsync(_url).Result;
                if (!string.IsNullOrEmpty(ver))
                {
                    return new Version(ver);
                }
                ConnexionOk = true;
                return null;
            }
            catch
            {
                ConnexionOk = false;
                Dispose();
                return null;
            }
        }

        public string GetVersion()
        {
            return Version.ToString();
        }

        public virtual void Dispose() => _httpClient.Dispose();
        #endregion
    }

}
