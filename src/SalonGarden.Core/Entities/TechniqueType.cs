using System.Collections.Generic;

namespace SalonGarden.Core.Entities
{
    public class TechniqueType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<TechniqueType> All 
        { 
            get
            {
                return new List<TechniqueType>()
                {
                    new TechniqueType(){Id = 1, Description = "Color"},
                    new TechniqueType(){Id = 2, Description = "Cut"},
                };
            }
        }
    }
}