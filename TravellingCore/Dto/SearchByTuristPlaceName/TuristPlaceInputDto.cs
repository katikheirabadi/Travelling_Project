using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.SearchByTuristPlaceName
{
    public class TuristPlaceInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int? TuristPlaceId { get; set; }
    }
}
