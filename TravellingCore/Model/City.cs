using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string Image { get; set; }
        public Country Country { get; set; }
        public List<TuristPlace> TuristPlaces { get; set; }
    }
}
