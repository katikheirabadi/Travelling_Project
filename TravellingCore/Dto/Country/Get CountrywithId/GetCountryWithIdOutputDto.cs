using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.Country.Get_CountrywithId
{
    public class GetCountryWithIdOutputDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public List<CityDto> Cities { get; set; }
        public List<Place> Places { get; set; }
    }
}
