using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Coment.DeleteComment;
using TravellingCore.Dto.Coment.GetComment;
using TravellingCore.Dto.Coment.GetPlaceComment;
using TravellingCore.Dto.Coment.UpdateComment;
using TravellingCore.Exceptions;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services;
using TravellingCore.Services.Models.Services.CommentServise;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class ComentService :ICommentService 
    {
        private readonly IRepository<Comment> CommentRepository;
        private readonly IRepository<UserLogin> UserLoginRepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IMapper mapper;

        public ComentService(IRepository<Comment> CommentRepository,
                             IRepository<UserLogin> UserLoginRepository,
                             IRepository<TuristPlace> TuristPlaceRepository,
                             IMapper mapper)
        {
            this.CommentRepository = CommentRepository;
            this.UserLoginRepository = UserLoginRepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.mapper = mapper;
        }
       
        private async Task<UserLogin> FindUserLogin(string Token)
        {
            var users = await UserLoginRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                throw new KeyNotFoundException("Not Found UserLogin");
            return user;
        }
        private void IsExpiresdToken(UserLogin user, string Token)
        {
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds <= 0)
                throw new ExpiredException("Yor Token Was Excpired");
            
        }
        private TuristPlace FindPlace(string placename)
        {
            var places =  TuristPlaceRepository.GetQuery();
            var place = places.FirstOrDefault(p => p.Name==(placename));
            if (place == null)
                throw new KeyNotFoundException("Not Found Place");
            return place;
        }
        private async Task<Comment> FindComment(int id)
        {
            var comments = await CommentRepository.GetAll();
            var endcomment = comments.FirstOrDefault(c => c.Id == id);
            if (endcomment == null)
                throw new KeyNotFoundException("Not found Comment with thid id");
            return endcomment;
        }
        private Comment ChangeCommment(Comment comment, string Text)
        {
            if(Text!=null)
            comment.Text = Text;
            
            return comment;
        }
        public async Task<string> AddComment(ComentInsertDto coment, string Token)
        {
            var user = await FindUserLogin(Token);
            IsExpiresdToken(user,Token);
            var place = FindPlace(coment.Turist_Place);
            CommentRepository.Insert(new Comment()
            {
                RecordDate = DateTime.Now,
                Text = coment.comment,
                UserId = user.UserId,
                TuristPlaceId = place.Id
            }) ;
            await CommentRepository.Save();
            return "we add your coment .";
           
        }
        public Task<List<GetCommentOutputDto>> ShowAllComments()
        {
            var comments = CommentRepository.GetQuery().Include(c => c.TuristPlace)
                                                       .Include(c => c.User)
                                                       .Select(c => mapper.Map<GetCommentOutputDto>(c)).ToListAsync();
            if (comments == null)
                throw new KeyNotFoundException("Not Fount any Comment");
            return comments;
        }
        public Task<List<GetPlacecommentsOutputDto>> ShowPlaceComments(GetPlaceCommentsInputDto getinput)
        {
            FindPlace(getinput.TuristPlaceName);
            var comments = CommentRepository.GetQuery().Include(c => c.User)
                                                        .Include(c => c.TuristPlace)
                                                        .Where(c => c.TuristPlace.Name == getinput.TuristPlaceName)
                                                        .Select(c => mapper.Map<GetPlacecommentsOutputDto>(c)).ToListAsync();
            if (comments == null)
                throw new KeyNotFoundException("not found any comment");
            return comments;
        }
        public async Task<string> UpdateComment(UpdateCommentInputdto updateinput)
        {
            var comment = await FindComment(updateinput.CommentId);
            var text = comment.Text;
            comment = ChangeCommment(comment, updateinput.Text);

            if (comment.Text ==text)
                return "We don't have any change..";

            var result =CommentRepository.Update(comment);
            await CommentRepository.Save();

            return result;
        }
        public async Task<string> DeleteComment(DeleteCommentInputDto deleteinput)
        {
            var result = CommentRepository.Delete(deleteinput.CommentId);
            await CommentRepository.Save();

            return result;
        }
        public async Task<GetCoomentOutputDto> GetComment(GetCommentInputDto getinput)
        {
            var findcomment = await FindComment(getinput.CommentId);
            findcomment = CommentRepository.GetQuery().Include(c => c.TuristPlace)
                                                      .Include(c => c.User)
                                                      .FirstOrDefault(c => c.Id == findcomment.Id);
            return mapper.Map<GetCoomentOutputDto>(findcomment);
        }

    }
}
