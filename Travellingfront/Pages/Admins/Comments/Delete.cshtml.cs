using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Coment.DeleteComment;
using TravellingCore.Services.Models.Services.CommentServise;

namespace Travellingfront.Pages.Admins.Comments
{
    public class DeleteModel : PageModel
    {
        private readonly ICommentService commentService;
        [BindProperty]
        public Boolean State { get; set; }
        public DeleteCommentInputDto deleteComment { get; set; }

        public DeleteModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                deleteComment = new DeleteCommentInputDto() { CommentId = id };
                var result = await commentService.DeleteComment(deleteComment);
                State = true;
                return RedirectToPage("./Comment");
            }
            catch (Exception e)
            {
                State = false;
                ViewData["Error"] = e.Message;
                return Page();
                
            }
        }
    }
}
