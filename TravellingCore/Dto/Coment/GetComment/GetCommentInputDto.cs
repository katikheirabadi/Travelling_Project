using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Coment.GetComment
{
    public class GetCommentInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int CommentId { get; set; }
    }
}
