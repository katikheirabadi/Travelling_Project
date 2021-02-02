﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Dto.SearchByName;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Model;

namespace TravellingCore.Mapp
{
    public class MappConfig : Profile
    {
        public MappConfig()
        {
            CreateMap<SigninInputDTO, User>().ForMember(o=> o.FullName , x=> x.MapFrom( p=> p.FullName))
                .ForMember(o => o.Username, x => x.MapFrom(p => p.Username))
                .ForMember(o => o.Password, x => x.MapFrom(p => p.Password))
                .ForMember(o => o.Re_Password, x => x.MapFrom(p => p.Re_Password))
                .ForMember(o => o.Phone_Number, x => x.MapFrom(p => p.Phone_Number));
            CreateMap<Turist_Place, NameOutputDTO>();

        }
    }
}
