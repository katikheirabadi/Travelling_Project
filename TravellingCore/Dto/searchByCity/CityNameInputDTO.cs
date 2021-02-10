using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.searchByCity
{
    public class CityNameInputDTO
    {
        [Required(ErrorMessage = "this field is empty")]
        public string CityName { get; set; }
    }
}
