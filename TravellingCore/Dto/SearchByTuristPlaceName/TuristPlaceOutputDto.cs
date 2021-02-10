using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.SearchByTuristPlaceName
{
    public class TuristPlaceOutputDto
    {
        public string TuristPlaceName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
    }
}
