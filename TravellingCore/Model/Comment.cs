using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Comment : IEntity
    {
        public int id { get; set; }
        public string Text { get; set; }
        public DateTime RecordDate { get; set; }
        public int userid { get; set; }
        public User user { get; set; }
        public int TP_id { get; set; }
        public Turist_Place TP_ { get; set; }
    }
}
