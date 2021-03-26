using chemicalElement.Data.Models;
using chemicalElement.DBModelUpdate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }

        public DbSet<Composed> Composeds { get; set; }
        public DbSet<Composition> Compositions { get; set; }

        public DbSet<Element> Elements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Element>()
                .HasKey(c => new { c..IdElement });

            modelBuilder.Entity<Composed>()
                .HasKey(c => c.IdComposed)
                ;
        }









    }
}
