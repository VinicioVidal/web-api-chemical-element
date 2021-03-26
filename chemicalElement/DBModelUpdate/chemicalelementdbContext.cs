using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace chemicalElement.DBModelUpdate
{
    public partial class chemicalelementdbContext : DbContext
    {
        public chemicalelementdbContext()
        {
        }

        public chemicalelementdbContext(DbContextOptions<chemicalelementdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Composed> Composeds { get; set; }
        public virtual DbSet<Composition> Compositions { get; set; }
        public virtual DbSet<Element> Elements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9DDTUMD\\SQLEXPRESS;Initial Catalog=chemical-element-db;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Composed>(entity =>
            {
                entity.HasKey(e => e.CodeComposed);

                entity.ToTable("Composed");

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Composition>(entity =>
            {
                entity.ToTable("Composition");

                entity.HasIndex(e => new { e.Symbol, e.CodeComposed }, "uq_composition")
                    .IsUnique();

                entity.Property(e => e.NumberOfAtoms).HasColumnName("numberOfAtoms");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodeComposedNavigation)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.CodeComposed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composition_Composed");

                entity.HasOne(d => d.SymbolNavigation)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.Symbol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composition_Element");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => e.Symbol);

                entity.ToTable("Element");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
