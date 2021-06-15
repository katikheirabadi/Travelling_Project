using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Coment.DeleteComment;
using TravellingCore.Dto.Coment.GetComment;
using TravellingCore.Dto.Coment.GetPlaceComment;
using TravellingCore.Dto.Coment.UpdateComment;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.CommentServise;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService CommentServise;

        public CommentController(ICommentService CommentServise)
        {
            this.CommentServise = CommentServise;
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody]ComentInsertDto coment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CommentServise.AddComment(coment);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllComments()
        {
            var result =await CommentServise.ShowAllComments();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowPlaceComments([FromBody] GetPlaceCommentsInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CommentServise.ShowPlaceComments(getinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowComment([FromBody]GetCommentInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CommentServise.GetComment(getinput);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromBody]DeleteCommentInputDto deleteinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result =await CommentServise.DeleteComment(deleteinput);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody]UpdateCommentInputdto updateinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CommentServise.UpdateComment(updateinput);
            return Ok(result);
        }
    }
}
