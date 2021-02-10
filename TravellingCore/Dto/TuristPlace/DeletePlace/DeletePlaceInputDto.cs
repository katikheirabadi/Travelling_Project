using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.DeletePlace
{
    public class DeletePlaceInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string Place { get; set; }
    }
}
