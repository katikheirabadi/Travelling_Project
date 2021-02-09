using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.GetPlace
{
    public class GetPlaceOutputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Comments { get; set; }
        public int Rates { get; set; }
        public int Categories { get; set; }
    }
}
