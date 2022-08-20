using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FuzzyLogicInterface.Models;

namespace FuzzyLogicInterface.Data
{
    public class FuzzyContext : DbContext
    {
        public FuzzyContext (DbContextOptions<FuzzyContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<ModuleRecord> ModulesData { get; set; }
        public DbSet<TestRecord> TestsData { get; set; }
        //public DbSet<TestRecord> TestsData { get; set; }

    }
}
