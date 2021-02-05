using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TuristPlaceCategory TuristPlaceCategory { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}
