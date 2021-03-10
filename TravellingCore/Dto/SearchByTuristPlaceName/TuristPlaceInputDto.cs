using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.SearchByTuristPlaceName
{
    public class TuristPlaceInputDto
    {
        [DisplayName("کجا میری؟؟")]
        [Required(ErrorMessage = "this field is empty")]
        public string TuristPlaceName { get; set; }
    }
}
