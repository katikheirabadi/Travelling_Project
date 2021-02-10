using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.SearchByFilter
{
    public class FilterOutputDetailDTO
    {
        public string TuristPlaceName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string[] Category { get; set; }
    }
}
