using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Dto._ُSearchByCategory;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.Popular;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByTuristPlaceName;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Dto.View;
using TravellingCore.Dto.Visit;
using TravellingCore.Model;

namespace TravellingCore.Mapp
{
    public class MappConfig : Profile
    {
        public MappConfig()
        {
            CreateMap<SigninInputDTO, User>().ForMember(o=> o.FullName , x=> x.MapFrom( p=> p.FullName))
                .ForMember(o => o.UserName, x => x.MapFrom(p => p.Username))
                .ForMember(o => o.Password, x => x.MapFrom(p => p.Password))
                .ForMember(o => o.RePassword, x => x.MapFrom(p => p.Re_Password))
                .ForMember(o => o.PhoneNumber, x => x.MapFrom(p => p.Phone_Number));

            CreateMap<TuristPlace, NewInputDTO>()
                .ForMember(x => x.Turist_Place_Name, y => y.MapFrom(z => z.Name));

            CreateMap<TuristPlace, CityOutputDTO>();

            CreateMap<TuristPlace, CountryOutPutDto>();

            CreateMap<TuristPlace, CategoryOutputDto>()
                .ForMember(o => o.TuristPlaceName , x => x.MapFrom(p => p.Name))
                .ForMember(o => o.Description , x => x.MapFrom(p => p.Description));

            CreateMap<TuristPlace, CountryOutPutDto>()
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(p => p.Name))
                .ForMember(o => o.CityOfCountry, x => x.MapFrom(p => p.City.Name))
                .ForMember(o => o.Description , x => x.MapFrom(p => p.Description));

            CreateMap<TuristPlace, TuristPlaceOutputDto>()
                .ForMember(o => o.TuristPlaceName , x => x.MapFrom(p => p.Name))
                .ForMember(o => o.CountryName , x => x.MapFrom(p => p.Country.Name))
                .ForMember(o => o.CityName , x => x.MapFrom(p => p.City.Name))
                .ForMember(o => o.Description , x => x.MapFrom(p => p.Description));

            CreateMap<TuristPlace, VisitOutputDto>()
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(p => p.Name))
                .ForMember(o => o.CityName, x => x.MapFrom(p => p.City.Name))
                .ForMember(o => o.CountryName, x => x.MapFrom(p => p.Country.Name));

            CreateMap<TuristPlace, ViewOutputDto>()
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(p => p.Name));

            CreateMap<TuristPlace, PopularOutputDto>();


        }
    }
}
