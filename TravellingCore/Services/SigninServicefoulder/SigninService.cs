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

namespace TravellingCore.ModelsServiceRepository.SigninRepository
{
    public class SigninService 
    {
        private readonly IRepository<User> repository;
        private readonly IMapper mapper;

        public SigninService(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<string> Signin(SigninInputDTO signin)
        {
            var usersignin = mapper.Map<User>(signin);
            if (usersignin.Password != usersignin.Re_Password)
                return "Re_Pasword is not Correct";
            var Users = await repository.GetAll();
            if (Users.FirstOrDefault(u => u.Username == usersignin.Username) != null)
                return "Accont whit this username exist...";
            repository.Insert(usersignin);
            await repository.Save();
            return $"Wellcome {usersignin.FullName}";
        }
    }
}

