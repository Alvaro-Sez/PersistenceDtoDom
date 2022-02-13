using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Productora.Data
{
    public partial class ProductoraDbContext : DbContext
    {
        

        public ProductoraDbContext(DbContextOptions<ProductoraDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<ActorEntity> Actors { get; set; }
        public virtual DbSet<DirectorEntity> Directors { get; set; }
        public virtual DbSet<PeliculaEntity> Peliculas { get; set; }
        public virtual DbSet<ProductoraEntity> Productoras { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ActorEntity>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Papel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeliculaId).HasColumnName("Pelicula_Id");

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.PeliculaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_Pelicula");
            });

            modelBuilder.Entity<DirectorEntity>(entity =>
            {
                entity.ToTable("Director");

                entity.HasIndex(e => e.PeliculaId, "IX_Director")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeliculaId).HasColumnName("Pelicula_Id");

                entity.HasOne(d => d.Pelicula)
                    .WithOne(p => p.Director)
                    .HasForeignKey<DirectorEntity>(d => d.PeliculaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Director_Pelicula1");
            });

            modelBuilder.Entity<PeliculaEntity>(entity =>
            {
                entity.ToTable("Pelicula");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductoraId).HasColumnName("Productora_Id");

                entity.Property(e => e.Tematica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Productora)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.ProductoraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Productora");
            });

            modelBuilder.Entity<ProductoraEntity>(entity =>
            {
                entity.ToTable("Productora");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
