using System;
using System.Linq.Expressions;
using SalonGarden.Core.Entities;

namespace SalonGarden.Core.Specifications
{
    public class OpenEvaluationsWithDetailsByStudent : BaseSpecification<Evaluation>
    {
        public OpenEvaluationsWithDetailsByStudent(string studentId) 
        : base(x => x.StudentId == studentId && x.EvaluationStatusId == (int)EvaluationStatuses.Open)
        {
            AddInclude(x => x.EvaluationType);
            AddInclude(x => x.EvaluationDetails);
            AddInclude("EvaluationDetails.EvaluationStep");
            AddInclude(x => x.EvaluationStatus);

            ApplyOrderByDescending(x => x.CreationDate);
        }
    }
}