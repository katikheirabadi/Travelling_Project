using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.NewPlace
{
    public class NewInputDTO
    {
        [Required(ErrorMessage = "this field is empty")]
        public int Id { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string TuristPlaceName { get; set; } 
        [Required(ErrorMessage = "this field is empty")]
        public string Image { get; set; }
    }
}
