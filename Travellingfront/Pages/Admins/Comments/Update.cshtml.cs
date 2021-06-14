using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Coment.UpdateComment;
using TravellingCore.Services.Models.Services.CommentServise;

namespace Travellingfront.Pages.Admins.Comments
{
    public class UpdateModel : PageModel
    {
        private readonly ICommentService commentService;

        public UpdateModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [BindProperty]
        public UpdateCommentInputdto updateComment { get; set; }
        public bool State { get; set; }
        public int CommentId { get; set; }
        public void OnGet(int id)
        {
            CommentId = id;
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await commentService.UpdateComment(updateComment);
                State = true;
                return RedirectToPage("./Comment");
            }
            catch (Exception e)
            {
                ViewData["Errore"] = e.Message;
                return Page();
            }
        }
    }
}
