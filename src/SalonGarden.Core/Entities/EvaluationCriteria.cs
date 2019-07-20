namespace SalonGarden.Core.Entities
{
    public class EvaluationCriteria
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SequenceNumber { get; set; }
        public int EvaluationCriteriaGroupId { get; set; }
        public int TotalPoints { get; set; }
    }
}