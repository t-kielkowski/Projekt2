using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class HZPContext : DbContext
    {
        public HZPContext()
        {
        }

        public HZPContext(DbContextOptions<HZPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dostawcy> Dostawcies { get; set; }
        public virtual DbSet<ListaSurowców> ListaSurowcóws { get; set; }
        public virtual DbSet<PozycjeZamówienium> PozycjeZamówienia { get; set; }
        public virtual DbSet<RodzajZlecenium> RodzajZlecenia { get; set; }
        public virtual DbSet<StatusZlecenium> StatusZlecenia { get; set; }
        public virtual DbSet<SurowceDostawcy> SurowceDostawcies { get; set; }
        public virtual DbSet<SurowcePółprodukty> SurowcePółprodukties { get; set; }
        public virtual DbSet<ZamówieniaDostawcy> ZamówieniaDostawcies { get; set; }
        public virtual DbSet<Zamówienium> Zamówienia { get; set; }
        public virtual DbSet<Zlecenium> Zlecenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PC-DOM;Initial Catalog=HZP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Dostawcy>(entity =>
            {
                entity.HasKey(e => e.IdDostawcy)
                    .HasName("PK__Dostawcy__1B2395A649FCECED");

                entity.ToTable("Dostawcy");

                entity.Property(e => e.IdDostawcy).ValueGeneratedNever();

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.DataZawarciaUmowy).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.KodPocztowy).HasMaxLength(10);

                entity.Property(e => e.Kraj).HasMaxLength(30);

                entity.Property(e => e.Miasto).HasMaxLength(20);

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(20);
            });

            modelBuilder.Entity<ListaSurowców>(entity =>
            {
                entity.HasKey(e => new { e.IdZlecenia, e.IdSurowca })
                    .HasName("PK__ListaSur__C65BC29035E84FA6");

                entity.ToTable("ListaSurowców");

                entity.HasOne(d => d.IdSurowcaNavigation)
                    .WithMany(p => p.ListaSurowcóws)
                    .HasForeignKey(d => d.IdSurowca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ListaSuro__IdSur__30F848ED");

                entity.HasOne(d => d.IdZleceniaNavigation)
                    .WithMany(p => p.ListaSurowcóws)
                    .HasForeignKey(d => d.IdZlecenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ListaSuro__IdZle__300424B4");
            });

            modelBuilder.Entity<PozycjeZamówienium>(entity =>
            {
                entity.HasKey(e => new { e.IdZamówienia, e.IdSurowca })
                    .HasName("PK__PozycjeZ__EB17D45069AD5B2F");

                entity.Property(e => e.CenaJednostkowa).HasColumnType("money");

                entity.Property(e => e.WartośćPozycji)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([CenaJednostkowa]*[Ilość])", false);

                entity.HasOne(d => d.IdSurowcaNavigation)
                    .WithMany(p => p.PozycjeZamówienia)
                    .HasForeignKey(d => d.IdSurowca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PozycjeZa__IdSur__36B12243");

                entity.HasOne(d => d.IdZamówieniaNavigation)
                    .WithMany(p => p.PozycjeZamówienia)
                    .HasForeignKey(d => d.IdZamówienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PozycjeZa__IdZam__35BCFE0A");
            });

            modelBuilder.Entity<RodzajZlecenium>(entity =>
            {
                entity.HasKey(e => e.IdRodzajZlecenia)
                    .HasName("PK__RodzajZl__55830A867FD663D6");

                entity.Property(e => e.IdRodzajZlecenia).ValueGeneratedNever();

                entity.Property(e => e.NazwaRodzajZlecenia)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<StatusZlecenium>(entity =>
            {
                entity.HasKey(e => e.IdStatusu)
                    .HasName("PK__StatusZl__8E121CD91FDF64BF");

                entity.Property(e => e.IdStatusu).ValueGeneratedNever();

                entity.Property(e => e.StatusZlecenia)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<SurowceDostawcy>(entity =>
            {
                entity.HasKey(e => new { e.IdSurowca, e.IdDostawcy })
                    .HasName("PK__SurowceD__DBE17EB53D46BB1B");

                entity.ToTable("SurowceDostawcy");

                entity.HasOne(d => d.IdDostawcyNavigation)
                    .WithMany(p => p.SurowceDostawcies)
                    .HasForeignKey(d => d.IdDostawcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SurowceDo__IdDos__3E52440B");

                entity.HasOne(d => d.IdSurowcaNavigation)
                    .WithMany(p => p.SurowceDostawcies)
                    .HasForeignKey(d => d.IdSurowca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SurowceDo__IdSur__3D5E1FD2");
            });

            modelBuilder.Entity<SurowcePółprodukty>(entity =>
            {
                entity.HasKey(e => e.IdSurowca)
                    .HasName("PK__SurowceP__AA5347EF5057EB93");

                entity.ToTable("SurowcePółprodukty");

                entity.Property(e => e.IdSurowca).ValueGeneratedNever();

                entity.Property(e => e.CenaJednostkowa).HasColumnType("money");

                entity.Property(e => e.IlośćJednostkowa).HasMaxLength(100);

                entity.Property(e => e.NazwaSurowca)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<ZamówieniaDostawcy>(entity =>
            {
                entity.HasKey(e => new { e.IdZamówienia, e.IdDostawcy })
                    .HasName("PK__Zamówien__7000D9743C767E4E");

                entity.ToTable("ZamówieniaDostawcy");

                entity.HasOne(d => d.IdDostawcyNavigation)
                    .WithMany(p => p.ZamówieniaDostawcies)
                    .HasForeignKey(d => d.IdDostawcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zamówieni__IdDos__4222D4EF");

                entity.HasOne(d => d.IdZamówieniaNavigation)
                    .WithMany(p => p.ZamówieniaDostawcies)
                    .HasForeignKey(d => d.IdZamówienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zamówieni__IdZam__412EB0B6");
            });

            modelBuilder.Entity<Zamówienium>(entity =>
            {
                entity.HasKey(e => e.IdZamówienia)
                    .HasName("PK__Zamówien__01B2E02E256EBAC7");

                entity.Property(e => e.IdZamówienia).ValueGeneratedNever();

                entity.Property(e => e.DataWymagana).HasColumnType("date");

                entity.Property(e => e.DataWysyłki).HasColumnType("date");

                entity.Property(e => e.DataZamówienia).HasColumnType("date");
            });

            modelBuilder.Entity<Zlecenium>(entity =>
            {
                entity.HasKey(e => e.IdZlecenia)
                    .HasName("PK__Zlecenia__2CFEF6EE535BB4DE");

                entity.Property(e => e.IdZlecenia).ValueGeneratedNever();

                entity.Property(e => e.DataPrzyjecia).HasColumnType("date");

                entity.Property(e => e.DataRozpoczecia).HasColumnType("date");

                entity.Property(e => e.NazwaTowaru)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NieprzekraczalnyTerminWykonania).HasColumnType("date");

                entity.Property(e => e.RzeczywistaDataZakonczenia).HasColumnType("date");

                entity.HasOne(d => d.IdRodzajZleceniaNavigation)
                    .WithMany(p => p.Zlecenia)
                    .HasForeignKey(d => d.IdRodzajZlecenia)
                    .HasConstraintName("FK__Zlecenia__IdRodz__29572725");

                entity.HasOne(d => d.IdStatusuNavigation)
                    .WithMany(p => p.Zlecenia)
                    .HasForeignKey(d => d.IdStatusu)
                    .HasConstraintName("FK__Zlecenia__IdStat__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
