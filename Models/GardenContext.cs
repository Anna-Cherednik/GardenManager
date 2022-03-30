using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GardenManager.Models
{
    public class GardenContext: DbContext
    {


        public DbSet<Coordinates> Coords { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Разметка> Разметки { get; set; }
        public DbSet<Територия> Територии { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>()
                .HasMany(p => p.ReversedPositivePlants)
                .WithMany(p => p.PositivePlants)
                .Map(m => m.ToTable("PositivePlants").MapLeftKey("Plant_Id").MapRightKey("Positive_Id"));

            modelBuilder.Entity<Plant>()
                .HasMany(p => p.ReversedNegativePlants)
                .WithMany(p => p.NegativePlants)
                .Map(m => m.ToTable("NegativePlants").MapLeftKey("Plant_Id").MapRightKey("Negative_Id"));

            base.OnModelCreating(modelBuilder);
        }
    }
}