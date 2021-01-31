﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Model;

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
        public Task Signin(SigninInputDTO signin)
        {
            repository.Insert(mapper.Map<User>(signin));
            return repository.Save();
        }
    }
}
