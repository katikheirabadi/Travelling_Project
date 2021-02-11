using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.User.DeleteUser
{
    public class DeleteUseiInputDto
    {
        [Required(ErrorMessage ="this field is empty")]
        public string UserName { get; set; }
    }
}
