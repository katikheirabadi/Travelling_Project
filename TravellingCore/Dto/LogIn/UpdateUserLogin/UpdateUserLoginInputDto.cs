using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.LogIn.UpdateUserLogin
{
   public  class UpdateUserLoginInputDto
    {
        [Required(ErrorMessage = "you must enter this field ")]
        public int LifeSpan { get; set; }
    }
}
