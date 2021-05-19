

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.ContextRepositoryInterface;

namespace TravellingCore.Model
{
    public class User : IdentityUser, IEntity
    {
        public string FullName { get; set; }
        public string RePassword { get; set; }
        public string Password { get; set; }
        public int? FavoriteCountry { get; set; }
        public int? FavoriteCategory { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        int IEntity.Id
        {
            get { return int.Parse(this.Id); }
            set { this.Id = value.ToString(); }
        }
    }
}