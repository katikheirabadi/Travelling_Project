using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Model;
using System.Linq;
using TravellingCore.Services.SigninServicefoulder;
using TravellingCore.Exceptions;
using TravellingCore.Dto.User.DeleteUser;
using TravellingCore.Dto.User.UpdateUser;
using TravellingCore.Dto.User.GetUser;

namespace TravellingCore.ModelsServiceRepository.SigninRepository
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> UserRepository;
        private readonly IMapper mapper;

        public UserService(IRepository<User> UserRepository,
                             IMapper mapper)
        {
            this.UserRepository = UserRepository;
            this.mapper = mapper;
        }
        private User CheckModel(SigninInputDTO signin)
        {
            var usersignin = mapper.Map<User>(signin);
            if (usersignin.Password == usersignin.RePassword)
                return usersignin;
            throw new DependencyException("Re-Pass not correct");
        }
        private async Task IsExistUser(User user)
        {
            var Users = await UserRepository.GetAll();
            var finduser = Users.FirstOrDefault(u => u.UserName == user.UserName);
            if ( finduser!= null)
                throw new ExistUserException("There is an accont with this username");
        }
        private async Task<User> FindUser(string username)
        {
            var users = await UserRepository.GetAll();
            var findUser = users.FirstOrDefault(p => p.UserName == username);
            if (findUser == null)
                throw new KeyNotFoundException("Not Found");
            return findUser;
        }
        public async Task<string> AddUser(SigninInputDTO signin)
        {
            var usersignin = CheckModel(signin);
            await IsExistUser(usersignin);

            UserRepository.Insert(usersignin);
            await UserRepository.Save();

            return $"Wellcome {usersignin.FullName}";
        }
        private  User ChangeUserToUpdate(User user ,UpdateUserOutputDto updateinput)
        {
            if (updateinput.Pasword != null)
            {
                user.Password = updateinput.Pasword;
                user.RePassword = user.Password;
            }
            if(updateinput.FullName!=null)
            {
                user.FullName = updateinput.FullName; 
            }
            return user;
        }
        public async Task<string> DeleteUser(DeleteUseiInputDto deleteinput)
        {
            var finduser =  await FindUser(deleteinput.UserName);
            var result = UserRepository.Delete(finduser.Id);
            await UserRepository.Save();
            return result;

        }
        public async Task<string> UpdateUser(UpdateUserOutputDto updateinput)
        {
            var user =  await FindUser(updateinput.Username);
            user =  ChangeUserToUpdate(user, updateinput);
           
            var result = UserRepository.Update(user);
            await UserRepository.Save();
            return result;

        }
        public async Task<GetUseroutputDto> ShowUser(GetUserInputDto getinput)
        {
            var finduser = await FindUser(getinput.Username);
            var getDetabase = await UserRepository.Get(finduser.Id);
            return mapper.Map<GetUseroutputDto>(finduser);
        }
        public async Task<List<GetUseroutputDto>> ShowAllUser()
        {
            var users = await UserRepository.GetAll();
            return users.Select(p => mapper.Map<GetUseroutputDto>(p)).ToList();
        }

    }
}

