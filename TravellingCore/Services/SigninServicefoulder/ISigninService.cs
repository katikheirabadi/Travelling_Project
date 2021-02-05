using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Sign_in;

namespace TravellingCore.Services.SigninServicefoulder
{
    public interface ISigninService
    {
        public Task<string> Signin(SigninInputDTO signin);
    }
}
