using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Dto.User.DeleteUser;
using TravellingCore.Dto.User.GetUser;
using TravellingCore.Dto.User.UpdateUser;

namespace TravellingCore.Services.SigninServicefoulder
{
    public interface IUserService
    {
        public Task<string> AddUser(SigninInputDTO signin);
        public Task<string> DeleteUser(DeleteUseiInputDto deleteinput);
        public Task<string> UpdateUser(UpdateUserOutputDto updateinput);
        public Task<GetUseroutputDto> ShowUser(GetUserInputDto getinput);
        public Task<List<GetUseroutputDto>> ShowAllUser();
        
    }
}
