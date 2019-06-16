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

        public Evaluation()
        {

        }

        
        public Evaluation(int evaluationTypeId, int techniqueId, string description, string educatorId, string studentId)
        {
            this.EvaluationTypeId = evaluationTypeId;
            this.TechniqueId = techniqueId;
            this.Description = description;
            this.EducatorId = educatorId;
            this.StudentId = studentId;
            EvaluationStepEntries = new List<EvaluationStepEntry>();
        }

    }
}
