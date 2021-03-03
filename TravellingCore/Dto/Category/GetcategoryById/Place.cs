using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.Category.GetcategoryById
{
    public class Place
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CommentsNumber { get; set; }
        public double AverageRates { get; set; }
        public int Visit { get; set; }
    }
}
