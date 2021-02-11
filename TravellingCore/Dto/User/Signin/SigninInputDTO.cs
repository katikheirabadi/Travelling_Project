using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Sign_in
{
    public class SigninInputDTO
    {
        [Required(ErrorMessage ="you must enter this field ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "you must enter this field ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "you must enter this field ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "you must enter this field ")]
        public string RePassword { get; set; }
       
        public string PhoneNumber { get; set; }
        public string FavoriteCountry { get; set; }
        public string FavoriteCategory { get; set; }
    }
}
