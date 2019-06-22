using System;
using System.Linq.Expressions;
using SalonGarden.Core.Entities;

namespace SalonGarden.Core.Specifications
{
    public class EvaluationWithDetails : BaseSpecification<Evaluation>
    {
        public EvaluationWithDetails(int evaluationId) : base(x => x.Id == evaluationId)
        {
            AddInclude(x => x.EvaluationDetails);
            AddInclude(x => x.EvaluationType);
        }
    }
}