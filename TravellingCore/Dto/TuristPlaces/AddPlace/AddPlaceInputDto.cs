using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.AddPlace
{
    public class AddPlaceInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string Name { get; set; } 
        [Required(ErrorMessage ="this field is empty")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Country { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Image { get; set; }

    }
}
