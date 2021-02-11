using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.User.UpdateUser
{
    public class UpdateUserOutputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        [EmailAddress(ErrorMessage ="this is not emailadress")]
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Pasword { get; set; }
    }
}
