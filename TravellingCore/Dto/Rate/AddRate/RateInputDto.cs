using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Rate
{
    public class RateInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        [Range(0,5)]
        public int Rate { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string place { get; set; }
    }
}
