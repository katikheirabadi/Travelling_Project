using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravellingCore.Dto.Coment.UpdateComment
{
    public class UpdateCommentInputdto
    {
        [Required(ErrorMessage = "this field is empty")]
        public int CommentId { get; set; }
        [Required(ErrorMessage = "this field is empty")]
        public string Text { get; set; }
    }
}
