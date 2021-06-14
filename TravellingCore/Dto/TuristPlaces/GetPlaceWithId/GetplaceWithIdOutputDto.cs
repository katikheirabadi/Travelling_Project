using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.TuristPlaces.GetPlaceWithId
{
    public class GetplaceWithIdOutputDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Visit { get; set; }
        public double AverageRates { get; set; }
    }
}
