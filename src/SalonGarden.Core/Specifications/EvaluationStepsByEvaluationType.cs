using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SalonGarden.Core.Entities;
using SalonGarden.Core.Interfaces;

namespace SalonGarden.Core.Specifications
{
    public class EvaluationStepsByEvaluationType : BaseSpecification<EvaluationCriteria>
    {
        public EvaluationStepsByEvaluationType(int evaluationTypeId) 
        : base(x => x.Id == evaluationTypeId)
        {
            ApplyOrderBy(x => x.SequenceNumber);
            
        }
    }
}