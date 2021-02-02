using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.LogIn
{
    public class LoginInputDto
    {
        [Required(ErrorMessage = "you must enter this field ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "you must enter this field ")]
        public string Password { get; set; }
    }
}
