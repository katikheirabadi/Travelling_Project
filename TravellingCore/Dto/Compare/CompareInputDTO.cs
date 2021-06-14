using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Compare
{
    public class CompareInputDTO
    {
        [Required(ErrorMessage = "این فیلد باید پر شود")]
        public string FirstPlace { get; set; }
        [Required(ErrorMessage = "این فیلد باید پر شود")]
        public string SecendPlace { get; set; }
    }
}
