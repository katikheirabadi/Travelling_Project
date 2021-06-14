using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Coment.DeleteComment;
using TravellingCore.Dto.Coment.GetComment;
using TravellingCore.Dto.Coment.GetPlaceComment;
using TravellingCore.Dto.Coment.UpdateComment;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.CommentServise
{
    public interface ICommentService 
    {
        public Task<string> AddComment(ComentInsertDto coment);
        public Task<GetCoomentOutputDto> GetComment(GetCommentInputDto getinput);
        public Task<List<GetCommentOutputDto>> ShowAllComments();
        public Task<List<GetPlacecommentsOutputDto>> ShowPlaceComments(GetPlaceCommentsInputDto getinput);
        public Task<string> UpdateComment(UpdateCommentInputdto updateinput);
        public Task<string> DeleteComment(DeleteCommentInputDto deleteinput);

    }
}
