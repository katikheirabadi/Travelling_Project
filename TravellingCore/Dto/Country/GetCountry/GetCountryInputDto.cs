using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Country.GetCountry
{
    public class GetCountryInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string YourCountry { get; set; }
    }
}
