namespace SalonGarden.Core.Entities
{
    public class EvaluationDetail
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int EvaluationCriterionId { get; set; }
        public int AllocatedPoints { get; set; }

        public EvaluationDetail()
        {
            
        }
        
        public EvaluationDetail(EvaluationCriterion evaluationCriterion)
        {
            EvaluationCriterionId = evaluationCriterion.Id;
        }
    }
}