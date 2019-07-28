using System;
using System.Collections.Generic;
using System.Linq;

namespace SalonGarden.Core.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public int EvaluationTypeId { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public int EvaluationStatusId { get; set; }
        public Technique Technique { get; set; }
        public int TechniqueId { get; set; }
        public string Description { get; set; }
        public string EducatorId { get; set; }
        public string StudentId { get; set; }
        public List<EvaluationDetailItem> EvaluationDetailItems { get; private set; }
        public DateTime CreationDate { get; set; }


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

        public void InitializeEvaluationStepEntries(IReadOnlyCollection<EvaluationCriteria> evaluationCriteria)
        {
            EvaluationDetailItems = new List<EvaluationDetailItem>();
            foreach (var criteria in evaluationCriteria)
            {
                var detail = new EvaluationDetailItem(criteria);
                EvaluationDetailItems.Add(detail);
            }
        }

        public void SetEvaluationDetailPoints(int evaluationStepEntryId, int points)
        {
            var evaluationStepEntry = EvaluationDetailItems.FirstOrDefault(x => x.Id == evaluationStepEntryId);

            if (evaluationStepEntry == null)
            {
                return;
            }

            evaluationStepEntry.AllocatedPoints = points;
        }



    }
}
