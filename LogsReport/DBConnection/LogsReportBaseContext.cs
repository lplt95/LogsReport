using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogsReport
{
    public partial class LogsReportBaseContext : DbContext
    {
        public LogsReportBaseContext()
        {
        }

        public LogsReportBaseContext(DbContextOptions<LogsReportBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logi> Logi { get; set; }
        public virtual DbSet<RodzajeCzytnikow> RodzajeCzytnikow { get; set; }
        public virtual DbSet<Zdarzenia> Zdarzenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logi>(entity =>
            {
                entity.HasKey(e => e.IdZdarzenia);

                entity.Property(e => e.IdZdarzenia)
                    .HasColumnName("id_zdarzenia")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataZdarzenia)
                    .HasColumnName("data_zdarzenia")
                    .HasColumnType("date");

                entity.Property(e => e.GodzinaZdarzenia).HasColumnName("godzina_zdarzenia");

                entity.Property(e => e.NumerRcpPracownika).HasColumnName("numer_rcp_pracownika");

                entity.Property(e => e.RodzajCzytnika).HasColumnName("rodzaj_czytnika");

                entity.Property(e => e.TypZdarzenia).HasColumnName("typ_zdarzenia");

                entity.HasOne(d => d.IdZdarzeniaNavigation)
                    .WithOne(p => p.Logi)
                    .HasForeignKey<Logi>(d => d.IdZdarzenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logi_Zdarzenia");

                entity.HasOne(d => d.RodzajCzytnikaNavigation)
                    .WithMany(p => p.Logi)
                    .HasForeignKey(d => d.RodzajCzytnika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logi_Rodzaje_Czytnikow");
            });

            modelBuilder.Entity<RodzajeCzytnikow>(entity =>
            {
                entity.HasKey(e => e.IdRodzaju);

                entity.ToTable("Rodzaje_Czytnikow");

                entity.Property(e => e.IdRodzaju)
                    .HasColumnName("id_rodzaju")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaRodzaju)
                    .IsRequired()
                    .HasColumnName("nazwa_rodzaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zdarzenia>(entity =>
            {
                entity.HasKey(e => e.IdZdarzenia);

                entity.Property(e => e.IdZdarzenia)
                    .HasColumnName("id_zdarzenia")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaZdarzenia)
                    .IsRequired()
                    .HasColumnName("nazwa_zdarzenia")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
