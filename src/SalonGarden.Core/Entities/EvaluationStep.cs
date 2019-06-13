namespace SalonGarden.Core.Entities
{
    public class EvaluationStep
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EvaluationTypeId { get; set; }
        public int SequenceNumber { get; set; }
        public int TotalPoints { get; set; }
    }
}