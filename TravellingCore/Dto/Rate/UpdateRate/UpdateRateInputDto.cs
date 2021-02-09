using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Rate.UpdateRate
{
    public class UpdateRateInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int RateId { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public int Rate { get; set; }
    }
}
