using Microsoft.AspNetCore.Identity;
using SalonGarden.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonGarden.Web.Models
{
    public class EditEvaluationViewModel
    {
        public Evaluation Evaluation { get; set; }
        public List<EvaluationCriteriaGroup> CriteriaGroups { get; set; }
        public IdentityUser Student { get; internal set; }
        public IdentityUser Educator { get; internal set; }
        
    }
}
