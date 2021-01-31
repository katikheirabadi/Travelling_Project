using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class UserLogin : IEntity
    {
        public int id { get; set; }
        public string Token { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int userid { get; set; }
        public User user { get; set; }
    }
}
