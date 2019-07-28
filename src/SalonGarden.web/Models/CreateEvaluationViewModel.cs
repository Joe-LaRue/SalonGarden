using Microsoft.AspNetCore.Mvc.Rendering;
using SalonGarden.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonGarden.Web.Models
{
    public class CreateEvaluationViewModel
    {
        public List<SelectListItem> TechniqueSelectList { get; set; }
        public List<SelectListItem> EvaluationTypesSelectList { get; set; }


    }
}
