using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Turist_PLace : IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
        public int Visit { get; set; }
    }
}
