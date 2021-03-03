using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Category.AddCategory
{
    public class AddCategoryInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string YourCategory { get; set; }
        [Required(ErrorMessage ="this field is empty")]
        public string Image { get; set; }
    }
}
