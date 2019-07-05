using SalonGarden.Core.Entities;
using System.Collections.Generic;

namespace SalonGarden.Infrastructure.Data
{
    public class SeedData
    {
        public SeedData()
        {

        }

        public List<EvaluationCriteriaGroup> EvaluationCriteriaGroups()
        {
            return new List<EvaluationCriteriaGroup>()
            {
                new EvaluationCriteriaGroup()
                {
                    Id = 1,
                    Description = "Greeting",
                    SequenceNumber = 1,
                    EvaluationCriteria = new List<EvaluationCriteria>()
                    {
                        new EvaluationCriteria(){ Id= 1, Description = "Warm Welcome", SequenceNumber = 1 },
                        new EvaluationCriteria(){ Id= 2, Description = "Introduction", SequenceNumber = 2 },
                    }
                },
                 new EvaluationCriteriaGroup()
                {
                    Id = 2,
                    Description = "Consultation",
                    SequenceNumber = 2,
                    EvaluationCriteria = new List<EvaluationCriteria>()
                    {
                        new EvaluationCriteria(){ Id= 3, Description = "Sensory Experience", SequenceNumber = 1 },
                        new EvaluationCriteria(){ Id= 4, Description = "Listening Skills", SequenceNumber = 2 },
                        new EvaluationCriteria(){ Id= 5, Description = "Appropriate Questions", SequenceNumber = 3},
                        new EvaluationCriteria(){ Id= 6, Description = "Maintenance/Product Reccomendations", SequenceNumber = 4},
                        new EvaluationCriteria(){ Id= 7, Description = "Review/Agreement", SequenceNumber = 5}
                    }
                },
                  new EvaluationCriteriaGroup()
                {
                    Id = 3,
                    Description = "Technical",
                    SequenceNumber = 3,
                    EvaluationCriteria = new List<EvaluationCriteria>()
                    {
                        new EvaluationCriteria(){ Id= 8, Description = "Shampoo/Massage/Cleanup", SequenceNumber = 1 },
                        new EvaluationCriteria(){ Id= 9, Description = "Clean Sections", SequenceNumber = 2 },
                        new EvaluationCriteria(){ Id= 10, Description = "Body Position", SequenceNumber = 3},
                        new EvaluationCriteria(){ Id= 11, Description = "Knowledge of Technique", SequenceNumber = 4},
                        new EvaluationCriteria(){ Id= 12, Description = "Control", SequenceNumber = 5},
                        new EvaluationCriteria(){ Id= 13, Description = "Cross Check/Balance", SequenceNumber = 6},
                        new EvaluationCriteria(){ Id= 14, Description = "Completed On Time", SequenceNumber = 7 },
                    }
                },
                   new EvaluationCriteriaGroup()
                {
                    Id = 4,
                    Description = "Professionalism",
                    SequenceNumber = 4,
                    EvaluationCriteria = new List<EvaluationCriteria>()
                    {
                         new EvaluationCriteria(){ Id= 15, Description = "Appropriate Conversation", SequenceNumber = 1 },
                        new EvaluationCriteria(){ Id= 16, Description = "Personal Appearance", SequenceNumber = 2 },
                        new EvaluationCriteria(){ Id= 17, Description = "Ask for Referrals/Rebooks", SequenceNumber = 3}
                    }
                },
                    new EvaluationCriteriaGroup()
                {
                    Id = 5,
                    Description = "Styling",
                    SequenceNumber = 5,
                    EvaluationCriteria = new List<EvaluationCriteria>()
                    {
                        new EvaluationCriteria(){ Id= 18, Description = "Explanation of Products", SequenceNumber = 1 },
                        new EvaluationCriteria(){ Id= 19, Description = "Sectioning", SequenceNumber = 2 },
                        new EvaluationCriteria(){ Id= 20, Description = "Control of Hair", SequenceNumber = 3},
                        new EvaluationCriteria(){ Id= 21, Description = "Teach Guest How to Recreate", SequenceNumber = 4},
                    }
                }
            };
        }

        public List<TechniqueType> GetTechniqueTypes()
        {
            return new List<TechniqueType>()
                {
                    new TechniqueType(){Id = 1, Description = "Color"},
                    new TechniqueType(){Id = 2, Description = "Cut"},
                };
        }

        public List<Technique> GetTechniques()
        {
            return new List<Technique>()
                {
                     //color
                    new Technique(){ Id = 1, TechniqueTypeId = 1, Description = "Vertical Foil"},
                    new Technique(){ Id = 2, TechniqueTypeId = 1, Description = "Diagonal Foil"},
                    new Technique(){ Id = 3, TechniqueTypeId = 1, Description = "Double Process"},
                    new Technique(){ Id = 4, TechniqueTypeId = 1, Description = "Single Process"},

                    //cut
                    new Technique(){ Id = 5, TechniqueTypeId = 2, Description = "Scissor Over Comb"},
                    new Technique(){ Id = 6, TechniqueTypeId = 2, Description = "Clipper Cut"},
                    new Technique(){ Id = 7, TechniqueTypeId = 2, Description = "Horizontal Graduation"},
                    new Technique(){ Id = 8, TechniqueTypeId = 2, Description = "Vertical Graduation"},
                    new Technique(){ Id = 9, TechniqueTypeId = 2, Description = "Triangular graduation"},
                    new Technique(){ Id = 10, TechniqueTypeId = 2, Description = "Short Graduation"},
                    new Technique(){ Id = 11, TechniqueTypeId = 2, Description = "Short Round Layer"},
                    new Technique(){ Id = 12, TechniqueTypeId = 2, Description = "Long Layer"}
                };
        }
    }
}