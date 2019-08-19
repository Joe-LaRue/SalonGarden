using SalonGarden.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonGarden.Web.Models
{
    public class EvaluationDto
    {
        public DateTime CreationDate { get; set; }
        public string StudentName { get; set; }
        public string EducatorName { get; set; }
        public string TechniqueName { get; set; }
        public string EvaluationType { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }


        public EvaluationDto(Evaluation evaluation)
        {
            CreationDate = evaluation.CreationDate;
            TechniqueName = evaluation.Technique.Description;
            EvaluationType = evaluation.EvaluationType.Description;
            Id = evaluation.Id;
            Score = 0; //evaluation.EvaluationDetailItems.Sum(x => x.AllocatedPoints);
        }
    }
}
