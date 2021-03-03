using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.SearchByCountry
{
    public class CountryInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int? CountryId { get; set; }
    }
}
