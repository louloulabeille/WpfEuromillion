using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class EuroDbContest : DbContext
{
    private readonly string _stringConnection;

    public EuroDbContest( string connexion)
    {
        _stringConnection = connexion;
    }

    public EuroDbContest(DbContextOptions<EuroDbContest> options, string connexion)
        : base(options)
    {
        _stringConnection = connexion;
    }

    public virtual DbSet<Tirage> Tirages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(_stringConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tirage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tirage__3213E83F5CD75BD7");

            entity.ToTable("Tirage");

            entity.HasIndex(e => e.NumTirage, "UQ__Tirage__CD0F0C61DBFB20DA").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateTirage).HasColumnType("date");
            entity.Property(e => e.Ecroissant)
                .HasMaxLength(3)
                .HasColumnName("ECroissant");
            entity.Property(e => e.Gagnant).HasDefaultValueSql("((0))");
            entity.Property(e => e.Tcroissant)
                .HasMaxLength(14)
                .HasColumnName("TCroissant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
