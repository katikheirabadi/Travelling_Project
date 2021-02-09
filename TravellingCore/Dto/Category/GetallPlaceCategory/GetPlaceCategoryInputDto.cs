using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Category.GetallPlaceCategory
{
    public class GetPlaceCategoryInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string PlaceName { get; set; }
    }
}
