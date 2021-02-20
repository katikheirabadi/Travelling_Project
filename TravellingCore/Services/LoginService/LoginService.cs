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
using TravellingCore.Dto.LogIn.ShowUserLogin;
using AutoMapper;

namespace TravellingCore.ServiceRepository.LoginService
{
    public class LoginServices : ILoginServicecs
    {
        private readonly IRepository<User> Userrepository;
        private readonly IRepository<UserLogin> UserLoginRepository;
        private readonly IMapper mapper;

        public LoginServices(IRepository<User> Userrepository,
                             IRepository<UserLogin> UserLoginRepository,
                             IMapper mapper)
        {
            this.Userrepository = Userrepository;
            this.UserLoginRepository = UserLoginRepository;
            this.mapper = mapper;
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
            return loginuser.Token;

        }
        public async Task<string> UpdateUserLogin(UpdateUserLoginInputDto update, string Token)
        {
            var userupdate = await FindToken(Token);
            userupdate.ExpireDate = userupdate.ExpireDate.AddDays(update.LifeSpan);
            var Result = UserLoginRepository.Update(userupdate);
            await UserLoginRepository.Save();
            return Result;
        }
        public async Task<ShowUserLoginOutputDto> ShowUserLogin(string Token)
        {
            var finduser = await FindToken(Token);
            return mapper.Map<ShowUserLoginOutputDto>(finduser);
        }
        public async Task<List<ShowUserLoginOutputDto>> ShowAllUserLogin()
        {
            var userlogins = await UserLoginRepository.GetAll();
            return userlogins.Select(u => mapper.Map<ShowUserLoginOutputDto>(u)).ToList();
        }

        private async Task<User> FindUser(LoginInputDto login)
        {
            var users = await Userrepository.GetAll();
            var finduser = users.FirstOrDefault(u => u.Password == login.Password && u.UserName == login.Username);
            if (finduser != null)
                return finduser;
            throw new KeyNotFoundException("Not Found");
        }
        private async Task<UserLogin> FindToken(string Token)
        {
            var userlogins = await UserLoginRepository.GetAll();
            var finduser = userlogins.FirstOrDefault(u => u.Token == Token);
            if (finduser != null)
                return finduser;
            throw new KeyNotFoundException("Not Found");
        }

    }
}
