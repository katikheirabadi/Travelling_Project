using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Favorite : IEntity
    {
        public int Id { get; set; }
        public int CategoryName { get; set; }
        public int CountryName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
