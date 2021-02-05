using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Coment;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services;
using TravellingCore.Services.Models.Services.CommentServise;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class ComentService :ICommentService , IModelServicees<Comment>
    {
        private readonly IRepository<Comment> CommentRepository;
        private readonly IRepository<UserLogin> UserLoginRepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        public ComentService(IRepository<Comment> CommentRepository, IRepository<UserLogin> UserLoginRepository, IRepository<TuristPlace> TuristPlaceRepository)
        {
            this.CommentRepository = CommentRepository;
            this.UserLoginRepository = UserLoginRepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
        }
        public string Delete(int id)
        {
            return CommentRepository.Delete(id);
        }

        public Task<Comment> Get(int id)
        {
            return CommentRepository.Get(id);
        }

        public Task<List<Comment>> GetAll()
        {
            return CommentRepository.GetAll();
        }

        public IQueryable<Comment> GetQuery()
        {
            return CommentRepository.GetQuery();
        }

        public async Task<string> AddComment(ComentInsertDto coment, string Token)
        {
            var users = await UserLoginRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                return "We don't have any Login-user with this Token ";
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds < 0)
                return "your accont has expierd and you must log in again";
            var places =  TuristPlaceRepository.GetQuery();
            var place = places.FirstOrDefault(p => p.Name==(coment.Turist_Place));
            if (place == null)
                return "Not found any place with this name";

            CommentRepository.Insert(new Comment()
            {
                RecordDate = DateTime.Now,
                Text = coment.comment,
                userid = user.userid,
                TP_id = place.id
            }) ;
           
            return "we add your coment .";
           
        }

        public Task Save()
        { 
            return CommentRepository.Save();
        }

        public string Update(Comment item)
        {
            return CommentRepository.Update(item);
        }
        public void Insert(Comment comment)
        {
            CommentRepository.Insert(comment);
        }
    }
}
