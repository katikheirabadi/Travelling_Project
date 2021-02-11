using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.User.GetUser
{
    public class GetUserInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public string Username { get; set; }
    }
}
