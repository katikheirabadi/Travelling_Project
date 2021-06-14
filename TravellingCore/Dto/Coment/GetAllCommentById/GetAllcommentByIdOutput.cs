using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Dto.Coment.GetAllByIdComment
{
    public class GetAllcommentByIdOutput
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int PlaceId { get; set; }
    }
}
