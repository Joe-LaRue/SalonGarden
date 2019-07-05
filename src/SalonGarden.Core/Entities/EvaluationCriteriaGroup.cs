using System;
using System.Collections.Generic;
using System.Text;

namespace SalonGarden.Core.Entities
{
    public class EvaluationCriteriaGroup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SequenceNumber { get; set; }
        public List<EvaluationCriteria> EvaluationCriteria { get; set; }

    }
}
