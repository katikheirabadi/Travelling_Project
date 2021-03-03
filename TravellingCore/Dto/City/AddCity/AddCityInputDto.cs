using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.City.AddCity
{
    public class AddCityInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string Country { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string City { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Image { get; set; }
    }
}
