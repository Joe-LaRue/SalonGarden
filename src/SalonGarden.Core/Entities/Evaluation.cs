using System.Collections.Generic;

namespace SalonGarden.Core.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int EvaluationTypeId { get; set; }
        public int TechniqueId { get; set; }
        public string Description { get; set; }
        public string EducatorId { get; set; }
        public string StudentId { get; set; }
        public List<EvaluationStepEntry> EvaluationStepEntries { get; set; }
        
        
    }
}
