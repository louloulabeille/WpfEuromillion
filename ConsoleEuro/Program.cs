// See https://aka.ms/new-console-template for more information
using BOL;
using DAL;
using DAL.Integration;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

void ExisteTirage(string tirage)
{
    Console.WriteLine($"Le tirage existe dans la base de données. {tirage}");
}

void ExistePasTirage(string tirage)
{
    Console.WriteLine($"Le tirage n'exite pas dans la base de données. {tirage}");
}

Console.WriteLine("Hello, World!");

/*string[] listeF = Directory.GetFiles("C:\\Users\\louloulabeille\\Desktop\\Euromillion");
IntegrationTirage integration = new(listeF);
integration.SetAll();
*/
using EuroDbContest contest = new ();
using UnitOfWork<Tirage> unit = new(contest); // générique
using UnitOfWorkTirage tirage = new(contest); // avec les méthodes spécifiques

/*UnitOfWork<TirageEqualityComparer> fdfd = new (contest); // a gérer exception
fdfd.Entities.GetAll();*/

AfficheMessage affiche; // déclaration du délégate

Tirage tir = new()
{
    Boule1 = 40,
    Boule2 = 29,
    Boule3 = 1,
    Boule4 = 28,
    Boule5 = 36,
    Etoile1 = 09,
    Etoile2 = 05,
};

affiche = tirage.Entities.TirageExist(tir) ? ExisteTirage : ExistePasTirage;
affiche(tir.ToString());

Tirage recherche = new()
{
    Boule1 = 42,
    Boule2 = 45,
    Boule3 = 13,
    Boule4 = 48,
    Boule5 = 12,
    Etoile1 = 3,
    Etoile2 = 9,
    Tcroissant = "48-45-42-13-12",
    Ecroissant = "3-9"
};

Tirage recherche2 = new()
{
    NumTirage = 2011008,
    DateTirage = new DateTime(2011,02,25),
    Gagnant = false,
    Boule1 = 42,
    Boule2 = 45,
    Boule3 = 13,
    Boule4 = 48,
    Boule5 = 12,
    Etoile1 = 3,
    Etoile2 = 9,
    Tcroissant = "48-45-42-13-12",
    Ecroissant = "3-9"
};

List<Tirage> tirages = contest.Tirages.ToList<Tirage>();
int toto = tirages.Where(tirage => tirage.Id==11).Select(tirage => tirage.GetHashCode()).First();
Console.WriteLine(toto+ " " + recherche.GetHashCode());
Console.WriteLine(recherche.Equals(tirages.Where(x=>x.Id==11).First<Tirage>()));

affiche = tirage.Entities.TirageExist(recherche2) ? ExisteTirage : ExistePasTirage;
affiche(recherche.ToString());

var ici = unit.Entities.Find(x => x.Ecroissant== "3-9" && x.Tcroissant== "48-45-42-13-12").FirstOrDefault();
Console.WriteLine(ici.ToString());

//DateTime date = tirages.Max(e => e.DateTirage).Date;
//Console.WriteLine(date.ToString("D"));

Console.ReadLine();

delegate void AfficheMessage(string tirage);

