using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Category.DeleteCategory
{
    public class DeleteCategoryInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public string DeleteCategory { get; set; }
    }
}
