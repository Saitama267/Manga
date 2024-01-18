using System;
using System.Collections.Generic;
using Manga_BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manga_DAL.Database;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.MangaGenre).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DateAppear).HasColumnType("date");
            entity.Property(e => e.DateDisappear).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(50);

            entity.HasOne(d => d.Character).WithOne(p => p.Feature)
                .HasForeignKey<Feature>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Features_Characters");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
