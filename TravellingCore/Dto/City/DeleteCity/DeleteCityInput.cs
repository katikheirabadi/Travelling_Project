using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.City.DeleteCity
{
    public class DeleteCityInput
    {
        [Required(ErrorMessage ="this field is empty")]
        public string YourCity { get; set; }
    }
}
