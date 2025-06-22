using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Models;

public partial class KolokwiumContext : DbContext
{
    public KolokwiumContext()
    {
    }

    public KolokwiumContext(DbContextOptions<KolokwiumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceParticipation> RaceParticipations { get; set; }

    public virtual DbSet<Racer> Racers { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<TrackRace> TrackRaces { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=kolokwium;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("Race_pk");

            entity.ToTable("Race");

            entity.Property(e => e.RaceId).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RaceParticipation>(entity =>
        {
            entity.HasKey(e => new { e.TrackRaceId, e.RacerId }).HasName("Race_Participation_pk");

            entity.ToTable("Race_Participation");

            entity.HasOne(d => d.Racer).WithMany(p => p.RaceParticipations)
                .HasForeignKey(d => d.RacerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Race_Participation_Racer");

            entity.HasOne(d => d.TrackRace).WithMany(p => p.RaceParticipations)
                .HasForeignKey(d => d.TrackRaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Race_Participation_Track_Race");
        });

        modelBuilder.Entity<Racer>(entity =>
        {
            entity.HasKey(e => e.RacerId).HasName("Racer_pk");

            entity.ToTable("Racer");

            entity.Property(e => e.RacerId).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("Track_pk");

            entity.ToTable("Track");

            entity.Property(e => e.TrackId).ValueGeneratedNever();
            entity.Property(e => e.LengthInKm).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TrackRace>(entity =>
        {
            entity.HasKey(e => e.TrackRaceId).HasName("Track_Race_pk");

            entity.ToTable("Track_Race");

            entity.Property(e => e.TrackRaceId).ValueGeneratedNever();

            entity.HasOne(d => d.Race).WithMany(p => p.TrackRaces)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Track_Race_Race");

            entity.HasOne(d => d.Track).WithMany(p => p.TrackRaces)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Track_Race_Track");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
