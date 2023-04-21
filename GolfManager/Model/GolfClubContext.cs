using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GolfManager.Model;

public partial class GolfClubContext : IdentityUserContext<IdentityUser>
{
    public GolfClubContext()
    {
    }

    public GolfClubContext(DbContextOptions<GolfClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Hole> Holes { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayersClub> PlayersClubs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.Idclub);

            entity.Property(e => e.Idclub)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("IDClub");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Hole>(entity =>
        {
            entity.HasKey(e => e.Idhole);

            entity.Property(e => e.Idhole)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("IDHole");
            entity.Property(e => e.Idclub).HasColumnName("IDClub");

            entity.HasOne(d => d.IdclubNavigation).WithMany(p => p.Holes)
                .HasForeignKey(d => d.Idclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Holes_Clubs");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Idplayer);

            entity.Property(e => e.Idplayer)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("IDPlayer");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PlayersClub>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Idclub).HasColumnName("IDClub");
            entity.Property(e => e.Idplayer).HasColumnName("IDPlayer");
            entity.Property(e => e.SubscriptionDate).HasColumnType("date");

            entity.HasOne(d => d.IdclubNavigation).WithMany()
                .HasForeignKey(d => d.Idclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayersClubs_Clubs");

            entity.HasOne(d => d.IdplayerNavigation).WithMany()
                .HasForeignKey(d => d.Idplayer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayersClubs_Players");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
