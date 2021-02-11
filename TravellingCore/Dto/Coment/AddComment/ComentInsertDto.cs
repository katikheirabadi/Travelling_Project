using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Coment
{
    public class ComentInsertDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string comment { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string TuristPlace { get; set; }
    }
}
