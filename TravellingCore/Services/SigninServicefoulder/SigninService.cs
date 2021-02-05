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

namespace TravellingCore.ModelsServiceRepository.SigninRepository
{
    public class SigninService : ISigninService
    {
        private readonly IRepository<User> SigninRepository;
        private readonly IMapper mapper;

        public SigninService(IRepository<User> SigninRepository, IMapper mapper)
        {
            this.SigninRepository = SigninRepository;
            this.mapper = mapper;
        }
        public async Task<string> Signin(SigninInputDTO signin)
        {
            var usersignin = mapper.Map<User>(signin);
            if (usersignin.Password != usersignin.RePassword)
                return "Re_Pasword is not Correct";
            var Users = await SigninRepository.GetAll();
            if (Users.FirstOrDefault(u => u.UserName == usersignin.UserName) != null)
                return "Accont whit this username exist...";
            SigninRepository.Insert(usersignin);
            await SigninRepository.Save();
            return $"Wellcome {usersignin.FullName}";
        }
    }
}

