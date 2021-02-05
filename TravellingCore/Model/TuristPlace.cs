using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class TuristPlace : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string Description { get; set; }
        public int Visit { get; set; }
        public string Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public TuristPlaceCategory TuristPlaceCategory { get; set; }
        public City City { get; set; }
    }
}
