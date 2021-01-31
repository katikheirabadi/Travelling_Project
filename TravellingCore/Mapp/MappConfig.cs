using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Model;

namespace TravellingCore.Mapp
{
    public class MappConfig : Profile
    {
        public MappConfig()
        {
            CreateMap<SigninInputDTO, User>();
        }
    }
}
