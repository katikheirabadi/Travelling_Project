using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto._ُSearchByCategory
{
    public class CategoryInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public string CategoryName { get; set; }
    }
}
