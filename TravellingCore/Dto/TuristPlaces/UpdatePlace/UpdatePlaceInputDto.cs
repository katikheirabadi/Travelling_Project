using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.UpdatePlace
{
    public class UpdatePlaceInputDto
    {
        public string Place { get; set; }
        public string NewDescription { get; set; }
        public string NewImage { get; set; }
    }
}
