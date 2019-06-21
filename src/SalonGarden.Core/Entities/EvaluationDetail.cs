namespace SalonGarden.Core.Entities
{
    public class EvaluationDetail
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int EvaluationStepId { get; set; }
        public int AllocatedPoints { get; set; }

        public EvaluationDetail()
        {
            
        }
        
        public EvaluationDetail(EvaluationStep evaluationStep)
        {
            EvaluationStepId = evaluationStep.Id;
        }
    }
}