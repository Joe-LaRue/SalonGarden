using SalonGarden.Core.Interfaces;
using SalonGarden.Core.Entities;

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

            return evaluation;
        }
    }
}