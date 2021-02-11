using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Coment.DeleteComment
{
    public class DeleteCommentInputDto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int CommentId { get; set; }
    }
}
