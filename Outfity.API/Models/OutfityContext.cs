using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Outfity.API.Models;

public partial class OutfityContext : DbContext
{
    public OutfityContext()
    {
    }

    public OutfityContext(DbContextOptions<OutfityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AiHistory> AiHistories { get; set; }

    public virtual DbSet<ClosetItem> ClosetItems { get; set; }

    public virtual DbSet<ClosetItemTag> ClosetItemTags { get; set; }

    public virtual DbSet<Outfit> Outfits { get; set; }

    public virtual DbSet<OutfitItem> OutfitItems { get; set; }

    public virtual DbSet<StyleTag> StyleTags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3LK1VR1;Database=Outfity;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AiHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AI_Histo__3214EC073E6A1398");

            entity.ToTable("AI_History");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.AiHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AI_Histor__UserI__46E78A0C");
        });

        modelBuilder.Entity<ClosetItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClosetIt__3214EC07AF7BDA6B");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Material).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Occasion).HasMaxLength(50);
            entity.Property(e => e.Season).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.ClosetItems)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ClosetIte__UserI__3A81B327");
        });

        modelBuilder.Entity<ClosetItemTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClosetIt__3214EC07B20386E9");

            entity.HasOne(d => d.ClosetItem).WithMany(p => p.ClosetItemTags)
                .HasForeignKey(d => d.ClosetItemId)
                .HasConstraintName("FK__ClosetIte__Close__4CA06362");

            entity.HasOne(d => d.StyleTag).WithMany(p => p.ClosetItemTags)
                .HasForeignKey(d => d.StyleTagId)
                .HasConstraintName("FK__ClosetIte__Style__4D94879B");
        });

        modelBuilder.Entity<Outfit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outfits__3214EC076107740F");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsFavorite).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Outfits)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Outfits__UserId__3E52440B");
        });

        modelBuilder.Entity<OutfitItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutfitIt__3214EC072C08CE62");

            entity.HasOne(d => d.ClosetItem).WithMany(p => p.OutfitItems)
                .HasForeignKey(d => d.ClosetItemId)
                .HasConstraintName("FK__OutfitIte__Close__440B1D61");

            entity.HasOne(d => d.Outfit).WithMany(p => p.OutfitItems)
                .HasForeignKey(d => d.OutfitId)
                .HasConstraintName("FK__OutfitIte__Outfi__4316F928");
        });

        modelBuilder.Entity<StyleTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StyleTag__3214EC0767E16D73");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07844B64C4");

            entity.Property(e => e.BodyType).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HijabStyle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
