using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.City.GetCountryCities
{
    public class GetCountryCitiesInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public string YourCountry { get; set; }
    }
}

