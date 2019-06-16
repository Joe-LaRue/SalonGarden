using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SalonGarden.Core.Entities;
using SalonGarden.Core.Interfaces;

namespace SalonGarden.Core.Specifications
{
    public class EvaluationStepsByEvaluationType : BaseSpecification<EvaluationStep>
    {
        public EvaluationStepsByEvaluationType(int evaluationTypeId) 
        : base(x => x.EvaluationTypeId == evaluationTypeId)
        {
            ApplyOrderBy(x => x.SequenceNumber);
            
        }
    }
}