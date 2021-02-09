using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Rate.GetPlaceRates
{
    public class GetPlaceRatesInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string Place { get; set; }
    }
}
