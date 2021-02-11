using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Coment.GetPlaceComment
{
    public class GetPlaceCommentsInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public string TuristPlaceName { get; set; }
    }
}
