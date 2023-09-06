using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Integration
{
    public class ExtractionCSV
    {
        public string Path { get; set; }    // chemin du fichier
        public string[] Delimiter { get; set; } = new string[] { ";" }; // délimiter par défaut

        /// <summary>
        /// Constructeur de la classe qui intègre des fichiers csv
        /// </summary>
        /// <param name="liste">liste des fichiers à intégrer</param>
        /// <param name="chemin">chemin du repertoire d'intégration</param>
        public ExtractionCSV(string chemin)
        {
            Path = chemin;
        }

        public List<string[]> ExtractionData()
        {
            using TextFieldParser textCSV = new(Path);
            List<string[]> fichierCsv = new();
            textCSV.SetDelimiters(Delimiter);
            textCSV.HasFieldsEnclosedInQuotes = false;
            textCSV.ReadLine(); // lecture de la première ligne

            while (!textCSV.EndOfData)
            {
                string[]? fields = textCSV.ReadFields();
                if (fields is null) continue;
                fichierCsv.Add(fields);
            }

            textCSV.Close();
            return fichierCsv;
        }

    }
}
