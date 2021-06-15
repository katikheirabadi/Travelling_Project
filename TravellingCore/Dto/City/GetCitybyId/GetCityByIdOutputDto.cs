using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.City.GetCitybyId
{
    public class GetCityByIdOutputDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Place> Places { get; set; }
    }
}
