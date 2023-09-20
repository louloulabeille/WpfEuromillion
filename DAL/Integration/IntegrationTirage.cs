using Microsoft.EntityFrameworkCore;
using Outil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Integration
{
    public class IntegrationTirage
    {
        public string[] ListeFichier { get; set; }

        private List<Tirage> ListeTirage { get; set; } = new();

        private readonly EuroDbContest contest;

        public IntegrationTirage(string[] liste, EuroDbContest contest)
        {
            ListeFichier = liste;
            this.contest = contest;
        }

        public void SetAll()
        {
            try
            {
                foreach (var fichier in ListeFichier)
                {
                    if (!File.Exists(fichier)) continue;
                    Console.WriteLine(fichier);
                    ExtractionCSV cSV = new(fichier);
                    List<string[]> lignes = cSV.ExtractionData();

                    foreach (var ligne in lignes)
                    {
                        ListeTirage.Add(GetTirage(ligne));
                    }
                }
                contest.Tirages.AddRangeAsync(ListeTirage.ToArray());
                //Console.WriteLine(ListeTirage.Where<Tirage>(t => t.Tcroissant.Contains("28-16-20-")).First().Tcroissant);           

                contest.SaveChanges();
            }
            catch (DbUpdateException dUex)
            {
                Console.WriteLine(dUex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected static Tirage GetTirage(string[] ligneCsv)
        {
            string examDate = ligneCsv[2];
            int[] tabTriTirage = new int[] { int.Parse(ligneCsv[4]), int.Parse(ligneCsv[5]), int.Parse(ligneCsv[6]), int.Parse(ligneCsv[7]), int.Parse(ligneCsv[8]) };
            int[] tabTrie = TriPairImpaire.TriDesc(tabTriTirage);
            DateTime date = examDate.Contains('/') ? new DateTime(int.Parse(examDate.Substring(6, 4)), int.Parse(examDate.Substring(3, 2)), int.Parse(examDate[..2])) :
                new DateTime(int.Parse(examDate[..4]), int.Parse(examDate.Substring(4, 2)), int.Parse(examDate.Substring(6, 2)));

            //Console.WriteLine(date.ToString("dd/MM/yyyy"));

            Tirage tirage = new()
            {
                NumTirage = int.Parse(ligneCsv[0]),
                DateTirage = date,
                Boule1 = int.Parse(ligneCsv[4]),
                Boule2 = int.Parse(ligneCsv[5]),
                Boule3 = int.Parse(ligneCsv[6]),
                Boule4 = int.Parse(ligneCsv[7]),
                Boule5 = int.Parse(ligneCsv[8]),
                Etoile1 = int.Parse(ligneCsv[9]),
                Etoile2 = int.Parse(ligneCsv[10]),
                Tcroissant = tabTrie[0].ToString() + "-" + tabTrie[1].ToString() + "-" + tabTrie[2].ToString() + "-" + tabTrie[3].ToString() + "-" + tabTrie[4].ToString(),
                Ecroissant = ligneCsv[12].Substring(1, 3),
                Gagnant = ligneCsv[13] != "0" || ligneCsv[14] != "0",
            };


            return tirage;
        }


    }
}
