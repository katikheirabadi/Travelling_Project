using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.SearchByFilter
{
    public class FilterOutputDetailDTO
    {
        public string TuristPlaceName { get; set; }
        public int id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CommentsNumber { get; set; }
        public double AverageRates { get; set; }
        public int Visit { get; set; }

    }
}
