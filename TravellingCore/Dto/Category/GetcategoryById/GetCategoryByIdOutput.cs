using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Dto.Category.GetcategoryById;

namespace TravellingCore.Dto.Category.GetCategory
{
    public class GetCategoryByIdOutput
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public List<Place> Places { get; set; }
       
    }
}
