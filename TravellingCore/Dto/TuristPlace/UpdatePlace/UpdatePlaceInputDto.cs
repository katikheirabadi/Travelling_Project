using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.UpdatePlace
{
    public class UpdatePlaceInputDto
    {
        [Required(ErrorMessage ="this field is empty ")]
        public string Place { get; set; }
        [Required(ErrorMessage ="this field is empty ")]
        public string NewDescription { get; set; }
    }
}
