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
        public TuristPlace TuristPlaces { get; set; }
        public Category Categories { get; set; }
    }
}
