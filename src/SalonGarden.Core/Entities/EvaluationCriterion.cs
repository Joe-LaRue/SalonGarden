namespace SalonGarden.Core.Entities
{
    public class EvaluationCriterion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SequenceNumber { get; set; }
        public int EvaluationCriterionGroupId { get; set; }
        public int TotalPoints { get; set; }
    }
}