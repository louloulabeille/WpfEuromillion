using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class EuroDbContest : DbContext
{
    public EuroDbContest()
    {
    }

    public EuroDbContest(DbContextOptions<EuroDbContest> options)
        : base(options)
    {
    }

    public virtual DbSet<Tirage> Tirages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Euro;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=True;");

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
