using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.GetPlace
{
    public class GetPlaceInput
    {
        [Required(ErrorMessage = "this field is empty")]
        public string Name { get; set; }
    }
}
