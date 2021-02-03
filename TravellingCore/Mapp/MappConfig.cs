using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.SearchByAtr;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByName;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Dto.TPlace;
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
            CreateMap<Turist_Place, NewInputDTO>()
                .ForMember(x => x.Turist_Place_Name, y => y.MapFrom(z => z.Name));
            CreateMap<Turist_Place, CityOutputDTO>();
            CreateMap<Turist_Place, AtrOutputDTO>();
            CreateMap<Turist_Place, CountryOutPutDto>();
            CreateMap<Turist_Place, PlaceOutputDto>();
        }
    }
}
