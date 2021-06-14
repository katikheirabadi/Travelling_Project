using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.Rate.GetAll
{
    public class GetAllOutPutDto
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; }
        public int PlaceId { get; set; }
    }
}
