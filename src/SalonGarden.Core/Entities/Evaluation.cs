using System.Collections.Generic;
using System.Linq;

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
        public List<EvaluationStepEntry> EvaluationStepEntries { get; private set; }

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
        }

        public void InitializeEvaluationStepEntries(IReadOnlyCollection<EvaluationStep> evaluationSteps)
        {
            EvaluationStepEntries = new List<EvaluationStepEntry>();
             foreach (var evaluationStep in evaluationSteps)
            {
                var stepEntry = new EvaluationStepEntry(evaluationStep);
                EvaluationStepEntries.Add(stepEntry);
            }
        }

        public void SetEvaluationStepEntryPoints(int evaluationStepEntryId, int points)
        {
            var evaluationStepEntry = EvaluationStepEntries.FirstOrDefault(x => x.Id == evaluationStepEntryId);
                
            if (evaluationStepEntry == null)
            {
                return;
            }

            evaluationStepEntry.AllocatedPoints = points;
        }
    }
}
