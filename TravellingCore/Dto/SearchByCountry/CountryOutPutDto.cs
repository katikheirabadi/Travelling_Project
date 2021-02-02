using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.SearchByCountry
{
    public class CountryOutPutDto
    {
        public string Name { get; set; }
        public string Atrraction { get; set; }
        public string Description { get; set; }
    }
    public class CountryListOutPutDto
    {
        public List<CountryOutPutDto> Places { get; set; }
    }
}
