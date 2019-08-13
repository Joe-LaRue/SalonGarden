using Microsoft.AspNetCore.Identity;
using SalonGarden.Core.Entities;
using System.Collections.Generic;

namespace SalonGarden.Web.Models
{
    public class EvaluationDetailVIewModel
    {
        public Evaluation Evaluation  { get; set; }
        public List<EvaluationCriteriaGroup> CriteriaGroups { get; set; }
        public IdentityUser Student { get; internal set; }
        public IdentityUser Educator { get; internal set; }
    }
}