using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Category.GetCategory
{
    public class GetCategoryInputDto
    {
        [Required]
        public string YourCategory { get; set; }
    }
}
