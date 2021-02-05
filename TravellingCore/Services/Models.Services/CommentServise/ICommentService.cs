using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.CommentServise
{
    public interface ICommentService 
    {
        public Task<string> AddComment(ComentInsertDto coment, string Token);
        public string Delete(int id);
        public Task<Comment> Get(int id);
        public Task<List<Comment>> GetAll();
        public IQueryable<Comment> GetQuery();
        public Task Save();
        public string Update(Comment item);
        public void Insert(Comment item);
    }
}
