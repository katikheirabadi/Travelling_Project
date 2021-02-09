using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.Country.GetCountry
{
    public class GetCountryOutputDto
    {
        public string Name { get; set; }
        public int Cities { get; set; }
        public int TuristPlaces { get; set; }
    }
}
