using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.Popular
{
    public class PopularOutputDto
    {
        public int Id { get; set; }
        public string TuristPlaceName { get; set; }
        public double Rate { get; set; }
        public int Visit { get; set; }
    }
}
