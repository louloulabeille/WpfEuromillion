using System;
using System.Collections.Generic;

namespace DAL;

public partial class Tirage
{
    public int Id { get; set; }

    public int NumTirage { get; set; }

    public DateTime DateTirage { get; set; }

    public int Boule1 { get; set; }

    public int Boule2 { get; set; }

    public int Boule3 { get; set; }

    public int Boule4 { get; set; }

    public int Boule5 { get; set; }

    public int Etoile1 { get; set; }

    public int Etoile2 { get; set; }

    public string? Tcroissant { get; set; }

    public string? Ecroissant { get; set; }

    public bool? Gagnant { get; set; }

    public override int GetHashCode()
    {
        if (Tcroissant == null || Ecroissant is null) return -1;
        return Tuple.Create(Tcroissant,Ecroissant).GetHashCode();
    }

    /*public override int GetHashCode()
    {
        return base.GetHashCode();
    }*/

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is Tirage tirage)
        {
            return tirage.GetHashCode() == this.GetHashCode();
        }
        return false;
    }

    public override string ToString()
    {
        return $"Tirage {Tcroissant} / Etoile {Ecroissant}";
    }
}
