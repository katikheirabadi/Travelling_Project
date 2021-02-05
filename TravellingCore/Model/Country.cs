using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<TuristPlace> TuristPlaces { get; set; }
    }
}
