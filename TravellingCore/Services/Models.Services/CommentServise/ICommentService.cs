using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.CommentServise
{
    public interface ICommentService 
    {
        public Task<string> AddComment(ComentInsertDto coment, string Token);
    }
}
