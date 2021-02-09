using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlaceCategory.Regisster
{
    public class RegisterInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string Category { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string TuristPlace { get; set; }
    }
}
