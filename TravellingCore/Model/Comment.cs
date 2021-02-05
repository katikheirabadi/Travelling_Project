using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime RecordDate { get; set; }
        public int UserId { get; set; }
        public int TuristPlaceId { get; set; }
        public User User { get; set; }
        public TuristPlace TuristPlace { get; set; }
    }
}
