using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class Favorite : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
    }
}
