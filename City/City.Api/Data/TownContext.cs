using City.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Data
{
    public class TownContext : DbContext
    {
        public TownContext(DbContextOptions<TownContext> options) : base(options)
        {

        }

        public DbSet<Town> Towns { get; set; }
        public DbSet<Sight> Sights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Town>().HasKey("Id");
            modelBuilder.Entity<Town>().Property(t => t.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Town>().Property(t => t.Description).HasMaxLength(200);
            modelBuilder.Entity<Town>().Ignore(t => t.Sights);
            modelBuilder.Entity<Town>().HasData(TownData());

            modelBuilder.Entity<Sight>().HasKey("Id");
            modelBuilder.Entity<Sight>().Property(s => s.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Sight>().Property(s => s.Description).HasMaxLength(200);
            modelBuilder.Entity<Sight>().HasOne(s => s.Town).WithMany(t => t.Sights).HasForeignKey(s => s.TownId);
            modelBuilder.Entity<Sight>().HasData(SightData());
        }

        private Town[] TownData()
        {
            var town = new Town[]
            {
                new Town { Id = new Guid("213b70c1-24f8-4279-b36c-cbfd732f9f3b"), Name = "New York City", Description = "The one with that big park." },
                new Town { Id = new Guid("f9598a2e-2b3a-4dda-b7d9-c103144f510f"), Name = "Antwerp", Description = "The one with the cathedral that was never really finished." },
                new Town { Id = new Guid("404659b6-39d1-49be-bf29-c7df4501d7ee"), Name = "Paris", Description = "The one with that big tower." },
            };

            return town;
        }

        private Sight[] SightData()
        {
            var sight = new Sight[]
            {
                new Sight { Id = new Guid("e6a4ed1d-a17c-4bd8-994f-c6679157e464"), Name = "Central Park", Description = "The most visited urban park in the world!", TownId = new Guid("213b70c1-24f8-4279-b36c-cbfd732f9f3b") },
                new Sight { Id = new Guid("0691f43f-5388-4b68-a946-f2f9816c868c"), Name = "Empire State Building", Description = "A 102-story skyscrapper located in Midtown Manhatan.", TownId = new Guid("213b70c1-24f8-4279-b36c-cbfd732f9f3b") },
                new Sight { Id = new Guid("dca44c14-9615-407e-8f98-ab0e9b24bda6"), Name = "Cathedral of Our Lady", Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.", TownId = new Guid("f9598a2e-2b3a-4dda-b7d9-c103144f510f") },
                new Sight { Id = new Guid("a9c30a4a-30c0-458e-871e-8ee1741b54f2"), Name = "Antwerp Central Station", Description = "The finest example of railway architecture in Belgium.", TownId = new Guid("f9598a2e-2b3a-4dda-b7d9-c103144f510f") },
                new Sight { Id = new Guid("787ec76e-f3d0-4aa3-84e0-d8b13b844286"), Name = "Eiffel Tower", Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.", TownId = new Guid("404659b6-39d1-49be-bf29-c7df4501d7ee") },
                new Sight { Id = new Guid("e35de2a6-9e7f-4567-a84a-49239d9680ef"), Name = "The Louvra", Description = "The world's largest museum.", TownId = new Guid("404659b6-39d1-49be-bf29-c7df4501d7ee") },
            };

            return sight;
        }
    }
}
