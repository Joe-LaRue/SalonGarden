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
        public List<EvaluationDetail> EvaluationDetails { get; private set; }

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
            EvaluationDetails = new List<EvaluationDetail
            >();
             foreach (var evaluationStep in evaluationSteps)
            {
                var stepEntry = new EvaluationDetail
                (evaluationStep);
                EvaluationDetails.Add(stepEntry);
            }
        }

        public void SetEvaluationDetailPoints(int evaluationStepEntryId, int points)
        {
            var evaluationStepEntry = EvaluationDetails.FirstOrDefault(x => x.Id == evaluationStepEntryId);
                
            if (evaluationStepEntry == null)
            {
                return;
            }

            evaluationStepEntry.AllocatedPoints = points;
        }
    }
}
