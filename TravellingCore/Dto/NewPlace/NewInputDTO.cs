using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.NewPlace
{
    public class NewInputDTO
    {
        [Required(ErrorMessage = "this field is empty")]
        public string Atrraction { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Turist_Place_Name { get; set; }
    }
}
