using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Country.AddCountry
{
    public class AddCountryInputDto
    {
        [Required(ErrorMessage ="yhis field is empty")]
        public string YourCountry { get; set; }
        [Required(ErrorMessage = "yhis field is empty")]
        public string Image { get; set; }
    }
}
