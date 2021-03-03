using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Sign_in
{
    public class SigninInputDTO
    {
        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage ="پر کردن این فیلد الزامی می‌باشد.")]
        public string FullName { get; set; }
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string Username { get; set; }
        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string Password { get; set; }
        [DisplayName("تکرار رمز عبور")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string RePassword { get; set; }
        [DisplayName("شماره همراه")]
        public string PhoneNumber { get; set; }
        [DisplayName("کشور مورد علاقه")]
        public int FavoriteCountry { get; set; }
        [DisplayName("دسته بندی مورد علاقه")]
        public int FavoriteCategory { get; set; }
    }
}
