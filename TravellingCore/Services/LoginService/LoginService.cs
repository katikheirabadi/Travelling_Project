using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.LogIn;
using TravellingCore.Model;
using System.Linq;
using TravellingCore.Services.LoginService;
using TravellingCore.Dto.LogIn.UpdateUserLogin;

namespace TravellingCore.ServiceRepository.LoginService
{
    public class LoginServices : ILoginServicecs
    {
        private readonly IRepository<User> Userrepository;
        private readonly IRepository<UserLogin> UserLoginRepository;

        public LoginServices(IRepository<User> Userrepository,
                             IRepository<UserLogin> UserLoginRepository)
        {
            this.Userrepository = Userrepository;
            this.UserLoginRepository = UserLoginRepository;
        }

        public async Task<string> AddLogin(LoginInputDto login)
        {
            var finduser = await FindUser(login);
            var loginuser = new UserLogin()
            {
                UserId = finduser.Id,
                LoginDate = DateTime.Now,
                Token = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(1)
            };
            UserLoginRepository.Insert(loginuser);
            await UserLoginRepository.Save();
            return $"Wellcome to your accont";

        }
        private async Task<User> FindUser(LoginInputDto login)
        {
            var users = await Userrepository.GetAll();
            var finduser = users.FirstOrDefault(u => u.Password == login.Password && u.UserName == login.Username);
            if (finduser != null)
                return finduser;
            throw new Exception("Not Found");
        }

        //public async Task<string> UpdateUserLogin(UpdateUserLoginInputDto update , string Token)
        //{


        //}


        //Recomend by Faverits

        private async Task<LoginServices> FindUserLogin(string Token)
        {
            var finduser = await UserLoginRepository.GetAll().find(x => x.Token == Token)
            if (finduser == null)
                throw new KeyNotFoundException("Not Found");
            return finduser;
        }

        private void IsExpired(UserLogin user)
        {
            var TimeSpan = DateTime.Now - user.ExpireDate;
            if (TimeSpan = 0)
                throw new Exception("Expire");
        }


        public async Task<List<OutputDTO>> RecomendByFaverits(string Token)
        {
            var finduser = await FindUserLogin(Token);
            await IsExpired(finduser);
             var findsignuser = UserLoginRepository.GetQuery().Include(u => u.User)
                .FirstorDefult(u => u.id == finduser).Select(u => u.User).FirstorDefult();
            if(findsignuser.faveritCountry !=null)
            {
                var places = Token.Repository.GetQuery().Include(x => x.Country)
                    .Select(x => x.Country.Name == findsignuser.faveritCountry).ToList();
            }
            var places.Select(prop => AutoMapper.Mapper<DTO>).ToList();
            return places;
        }

    }
}
