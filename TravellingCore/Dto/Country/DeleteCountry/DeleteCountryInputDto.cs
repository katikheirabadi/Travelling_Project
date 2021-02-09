using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Country.DeleteCountry
{
    public class DeleteCountryInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string YourCountry { get; set; }
    }
}
