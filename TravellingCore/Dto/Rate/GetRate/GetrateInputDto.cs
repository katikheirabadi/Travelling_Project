using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Rate.GetRate
{
    public class GetrateInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public int RateId { get; set; }
    }
}
