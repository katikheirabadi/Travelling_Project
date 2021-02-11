using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Compare
{
    public class CompareInputDTO
    {
        [Required(ErrorMessage = "this field is empty")]
        public string FirstPlace { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string SecendPlace { get; set; }
    }
}
