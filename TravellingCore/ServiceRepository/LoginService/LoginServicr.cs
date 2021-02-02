﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.LogIn;
using TravellingCore.Model;
using System.Linq;

namespace TravellingCore.ServiceRepository.LoginService
{
    public class LoginServicr
    {
        private readonly IRepository<User> repository;
        private readonly IRepository<UserLogin> repository1;

        public LoginServicr(IRepository<User> repository,IRepository<UserLogin> repository1)
        {
            this.repository = repository;
            this.repository1 = repository1;
        }

        public async Task<string> AddLogin(LoginInputDto login)
        {
            var users = await repository.GetAll();
            var find_user = users.FirstOrDefault(u => u.Password == login.Password && u.Username == login.Username);
            if (find_user == null)
                return "Not Found Any User with this Information...";
            var loginuser = new UserLogin()
            {
                userid = find_user.id,
                LoginDate = DateTime.Now,
                Token = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(1)
            };

            var loginusers = await repository1.GetAll();
            var userlogin = loginusers.FirstOrDefault(lu => lu.userid == loginuser.userid);
            if (userlogin != null)
            {
                repository1.Update(loginuser);
                await repository.Save();
            }
            else
            {
                repository1.Insert(loginuser);
                await repository1.Save();
            }
            
            return $"Wellcome to your accont with code {loginuser.Token}";
            
        }
    }
}