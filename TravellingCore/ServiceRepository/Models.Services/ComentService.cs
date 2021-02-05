using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Coment;
using TravellingCore.Model;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class ComentService
    {
        private readonly IRepository<Comment> repository;
        private readonly IRepository<UserLogin> repository1;
        private readonly IRepository<TuristPlace> repository2;
        public ComentService(IRepository<Comment> repository,IRepository<UserLogin> repository1,IRepository<TuristPlace> repository2)
        {
            this.repository = repository;
            this.repository1 = repository1;
            this.repository2 = repository2;
        }
        public string Delete(int id)
        {
            return repository.Delete(id);
        }

        public Task<Comment> Get(int id)
        {
            return repository.Get(id);
        }

        public Task<List<Comment>> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<Comment> GetQuery()
        {
            return repository.GetQuery();
        }

        public async Task<string> Insert(ComentInsertDto coment, string Token)
        {
            var users = await repository1.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                return "We don't have any Login-user with this Token ";
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds < 0)
                return "your accont has expierd and you must log in again";
            var places =  repository2.GetQuery();
            var place = places.FirstOrDefault(p => p.Name==(coment.Turist_Place));
            if (place == null)
                return "Not found any place with this name";

            repository.Insert(new Comment()
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
            return repository.Save();
        }

        public string Update(Comment item)
        {
            return repository.Update(item);
        }
        public void Insert2(Comment comment)
        {
            repository.Insert(comment);
        }
    }
}
