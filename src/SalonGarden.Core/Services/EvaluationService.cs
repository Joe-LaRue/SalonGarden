using SalonGarden.Core.Interfaces;
using SalonGarden.Core.Entities;
using SalonGarden.Core.Specifications;
using System.Linq;

namespace SalonGarden.Core.Services
{
    public class EvaluationService
    {
        public ISalonGardenRepository _salonGardenRepository;
        public EvaluationService(ISalonGardenRepository salonGardenRepository)
        {
            _salonGardenRepository = salonGardenRepository;
        }

        public Evaluation CreateEvaluation(int evaluationTypeId, int techniqueId, string description, string educatorId, string studentId)
        {
            var evaluation = new Evaluation(evaluationTypeId, techniqueId, description, educatorId, studentId);

            _salonGardenRepository.Add(evaluation);
            var evaluationSteps = _salonGardenRepository.List(new EvaluationStepsByEvaluationType(evaluation.EvaluationTypeId));

            evaluation.InitializeEvaluationStepEntries(evaluationSteps);

            _salonGardenRepository.Update(evaluation);
            return evaluation;
        }
    }
}