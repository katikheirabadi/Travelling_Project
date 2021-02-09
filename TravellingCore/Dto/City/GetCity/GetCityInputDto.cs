using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.City.GetCity
{
    public class GetCityInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string YourCity { get; set; }
    }
}
