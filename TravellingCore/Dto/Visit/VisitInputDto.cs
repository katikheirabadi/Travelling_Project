using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Visit
{
     public class VisitInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public string TuristPlaceName { get; set; }
    }
}
