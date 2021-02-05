﻿using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Rate : IEntity
    {
        public int Id { get; set; }
        public int UserRate { get; set; }
        public int UserId { get; set; }
        public int TuristPlaceId { get; set; }
        public DateTime RecordDate { get; set; }
        public User user { get; set; }
        public TuristPlace Tp_ { get; set; }
    }
}
