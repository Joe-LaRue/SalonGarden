namespace SalonGarden.Core.Entities
{
    public class EvaluationDetailItem    
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int EvaluationCriteriaId { get; set; }
        public int AllocatedPoints { get; set; }

        public EvaluationDetailItem()
        {
            
        }
        
        public EvaluationDetailItem
        (EvaluationCriteria evaluationCriteria)
        {
            EvaluationCriteriaId = evaluationCriteria.Id;
        }
    }
}