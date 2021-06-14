using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Coment.GetAllByIdComment;
using TravellingCore.Services.Models.Services.CommentServise;

namespace Travellingfront.Pages.Admins.Comments
{
    public class CommentesModel : PageModel
    {
        private readonly ICommentService commentService;
        [BindProperty]
        public List<GetAllcommentByIdOutput> Commentes { get; set; }
        public CommentesModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task OnGet()
        {
            Commentes = await commentService.GetAll();
        }
    }
}
