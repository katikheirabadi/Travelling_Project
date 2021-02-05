using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.LogIn;

namespace TravellingCore.Services.LoginService
{
    public interface ILoginServicecs
    {
        public Task<string> AddLogin(LoginInputDto login);
    }
}
