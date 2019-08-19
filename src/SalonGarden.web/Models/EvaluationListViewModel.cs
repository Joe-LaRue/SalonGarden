using SalonGarden.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonGarden.Web.Models
{
    public class EvaluationListViewModel
    {
        public List<EvaluationDto> EvaluationDtos { get; set; } = new List<EvaluationDto>();
    }
}
