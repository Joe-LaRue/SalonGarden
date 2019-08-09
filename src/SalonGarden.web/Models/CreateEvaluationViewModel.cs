using Microsoft.AspNetCore.Mvc.Rendering;
using SalonGarden.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonGarden.Web.Models
{
    public class CreateEvaluationViewModel
    {
        public SelectList TechniqueSelectList { get; set; }
        public SelectList EvaluationTypesSelectList { get; set; }
        public SelectList UsersSelectList { get; set; }

        [Required]
        public string SelectedStudentId { get; set; }

        [Required]
        public int SelectedEvaluationTypeId { get; set; }

        [Required]
        public int SelectedTechniqueId { get; set; }

    }
}
