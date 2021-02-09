using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.LogIn;
using TravellingCore.Dto.LogIn.ShowUserLogin;
using TravellingCore.Dto.LogIn.UpdateUserLogin;

namespace TravellingCore.Services.LoginService
{
    public interface ILoginServicecs
    {
        public Task<string> AddLogin(LoginInputDto login);
        public Task<string> UpdateUserLogin(UpdateUserLoginInputDto update, string Token);
        public Task<ShowUserLoginOutputDto> ShowUserLogin(string Token);
        public Task<List<ShowUserLoginOutputDto>> ShowAllUserLogin();
    }
}
