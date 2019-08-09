
using Microsoft.EntityFrameworkCore;
using SalonGarden.Core.Entities;

namespace SalonGarden.Web.Data.SalonGarden
{
    public class SalonGardenContext : DbContext
    {

        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<TechniqueType> TechniqueTypes { get; set; }
        public DbSet<EvaluationStatus> EvaluationStatuses { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }
        public DbSet<EvaluationCriteriaGroup> EvaluationCriteriaGroups { get; set; }
        public DbSet<EvaluationType> EvaluationTypes { get; set; }

        public SalonGardenContext(DbContextOptions<SalonGardenContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EvaluationCriteriaGroup>().HasMany(x => x.EvaluationCriteria).WithOne().HasForeignKey(x => x.EvaluationCriteriaGroupId);

            modelBuilder.Entity<TechniqueType>().HasData(SeedData.TechniqueTypes());
            modelBuilder.Entity<Technique>().HasData(SeedData.Techniques());
            modelBuilder.Entity<EvaluationCriteriaGroup>().HasData(SeedData.EvaluationCriteriaGroups());
            modelBuilder.Entity<EvaluationCriteria>().HasData(SeedData.EvaluationCriterias());
            modelBuilder.Entity<EvaluationStatus>().HasData(SeedData.EvaluationStatuses());
            modelBuilder.Entity<EvaluationType>().HasData(SeedData.EvaluationTypes());
        }
    }
}