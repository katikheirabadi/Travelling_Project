using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class TuristPlaceCategory : IEntity
    {
        public int Id { get; set; }
        public int TuristPlaceId { get; set; }
        public int CaregoryId { get; set; }
        public List<TuristPlace> TuristPlaces { get; set; }
        public List<Category> Categories { get; set; }
    }
}
