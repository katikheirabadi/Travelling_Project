using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Rate.DeleteRate
{
    public class DeleterateInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int RateId { get; set; }
    }
}
