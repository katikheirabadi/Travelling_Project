using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.TuristPlace.AddPlace
{
    public class AddPlaceInputDto
    {
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string Name { get; set; } 
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامی می‌باشد.")]
        public string Image { get; set; }

    }
}
