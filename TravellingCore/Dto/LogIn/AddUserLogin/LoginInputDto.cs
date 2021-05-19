using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.LogIn
{
    public class LoginInputDto
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد")]
        [EmailAddress(ErrorMessage ="این فیلد بایدآدرس ایمیل باشد")]
        public string Username { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
