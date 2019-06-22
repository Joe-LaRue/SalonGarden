using System.Collections.Generic;
using SalonGarden.Core.Entities;

namespace SalonGarden.Core.SeedData
{
    public class Techniques
    {
        public static List<Technique> All
        {
            get
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
}