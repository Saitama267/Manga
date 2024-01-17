using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manga.Models;

public partial class MangaDbContext : DbContext
{
    public MangaDbContext()
    {
    }

    public MangaDbContext(DbContextOptions<MangaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MangaDb;TrustServerCertificate=true;MultipleActiveResultSets=true;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.MangaGenre).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);

            entity.HasOne(d => d.Feature).WithMany(p => p.Characters)
                .HasForeignKey(d => d.FeatureId)
                .HasConstraintName("FK_Characters_Features");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.Property(e => e.DateAppear).HasColumnType("date");
            entity.Property(e => e.DateDisappear).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
