using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Rate : IEntity
    {
        public int Id { get; set; }
        public int UserRate { get; set; }
        public string UserId { get; set; }
        public int TuristPlaceId { get; set; }
        public DateTime RecordDate { get; set; }
        public User User { get; set; }
        public TuristPlace TuristPlace { get; set; }
    }
}
