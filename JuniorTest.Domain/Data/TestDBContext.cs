using JuniorTest.Domain.DomainModels;
using JuniorTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Data
{
    public class TestDBContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<TestDBContext>();
                OpsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = OpsBuilder.Options;
            }

            public DbContextOptionsBuilder<TestDBContext> OpsBuilder { get; set; }
            public DbContextOptions<TestDBContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Setting relations between models
            builder.Entity<ProductionFacility>()
                .HasMany(c => c.Contracts)
                .WithOne(f => f.Facility);

            builder.Entity<TechnologicalEquipment>()
                .HasMany(c => c.Contracts)
                .WithOne(e => e.Equipment);

            #endregion

            #region Seed DB
            builder.Entity<ProductionFacility>()
                .HasData(new List<ProductionFacility>()
                {
                    new ProductionFacility{Id=1, Name="testName1", Square=450},
                    new ProductionFacility{Id=2, Name="testName2", Square=600},
                    new ProductionFacility{Id=3, Name="testName3", Square=350},
                    new ProductionFacility{Id=4, Name="testName4", Square=200},

                });
            builder.Entity<TechnologicalEquipment>()
                .HasData(new List<TechnologicalEquipment>()
                {
                    new TechnologicalEquipment{Id=1, Name="testName1", Square=50},
                    new TechnologicalEquipment{Id=2, Name="testName2", Square=90},
                    new TechnologicalEquipment{Id=3, Name="testName3", Square=120},
                    new TechnologicalEquipment{Id=4, Name="testName4", Square=75},
                });
            #endregion

        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ProductionFacility> Facilities { get; set; }
        public DbSet<TechnologicalEquipment> Equipments { get; set; }
    }
}
