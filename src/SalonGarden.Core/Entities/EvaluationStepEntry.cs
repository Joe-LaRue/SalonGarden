namespace SalonGarden.Core.Entities
{
    public class EvaluationStepEntry
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int EvaluationStepId { get; set; }
        public int AllocatedPoints { get; set; }
        
    }
}