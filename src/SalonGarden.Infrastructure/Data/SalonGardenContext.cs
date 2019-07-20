
using Microsoft.EntityFrameworkCore;
using SalonGarden.Core.Entities;

namespace SalonGarden.Infrastructure.Data
{
    public class SalonGardenContext : DbContext
    {

        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }
        public DbSet<EvaluationCriteriaGroup> EvaluationCriteriaGroups { get; set; }
        
        public SalonGardenContext(DbContextOptions<SalonGardenContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}