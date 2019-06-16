using SalonGarden.Core.Interfaces;
using SalonGarden.Core.Entities;
using SalonGarden.Core.Specifications;

namespace SalonGarden.Core.Services
{
    public class EvaluationService
    {
        public ISalonGardenRepository _salonGardenRepository;
        public EvaluationService(ISalonGardenRepository salonGardenRepository)
        {
            _salonGardenRepository = salonGardenRepository;
        }

        public Evaluation CreateEvaluation(int evaluationTypeId, int techniqueId, string description, string educatorId, string studentId){
            var evaluation = new Evaluation(evaluationTypeId, techniqueId, description, educatorId, studentId);

            _salonGardenRepository.Add(evaluation);

            var evaluationSteps =  _salonGardenRepository.List(new EvaluationStepsByEvaluationType(evaluation.EvaluationTypeId));

            foreach (var evaluationStep in evaluationSteps)
            {
                var stepEntry = new EvaluationStepEntry(evaluationStep);
                evaluation.EvaluationStepEntries.Add(stepEntry);
            }

            _salonGardenRepository.Update(evaluation);
            return evaluation;
        }
    }
}