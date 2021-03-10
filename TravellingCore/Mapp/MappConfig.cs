using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingCore.Dto._ُSearchByCategory;
using TravellingCore.Dto.Category.GetallPlaceCategory;
using TravellingCore.Dto.Category.GetCategory;
using TravellingCore.Dto.City.GetCity;
using TravellingCore.Dto.Coment.GetComment;
using TravellingCore.Dto.Coment.GetPlaceComment;
using TravellingCore.Dto.Country.GetCountry;
using TravellingCore.Dto.LogIn.ShowUserLogin;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.Rate.GetPlaceRates;
using TravellingCore.Dto.Rate.GetRate;
using TravellingCore.Dto.Popular;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Dto.SearchByTuristPlaceName;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Dto.User.GetUser;
using TravellingCore.Dto.View;
using TravellingCore.Dto.Visit;
using TravellingCore.Model;
using TravellingCore.Dto.Favorites;

namespace TravellingCore.Mapp
{
    public class MappConfig : Profile
    {
        public MappConfig()
        {
            //mapp for user
            CreateMap<SigninInputDTO, User>()
                .ForMember(o=> o.FullName, x=> x.MapFrom( p=> p.FullName))
                .ForMember(o => o.UserName, x => x.MapFrom(p => p.Username))
                .ForMember(o => o.Password, x => x.MapFrom(p => p.Password))
                .ForMember(o => o.RePassword, x => x.MapFrom(p => p.RePassword))
                .ForMember(o => o.PhoneNumber, x => x.MapFrom(p => p.PhoneNumber))
                .ForMember(o => o.FavoriteCountry, x => x.MapFrom(p => p.FavoriteCountry))
                .ForMember(o => o.FavoriteCategory, x => x.MapFrom(p => p.FavoriteCategory));
            
            CreateMap<TuristPlace, CityPlaceOutputDTO>();

            CreateMap<TuristPlace, CountryOutPutDto>();

            CreateMap<UserLogin, ShowUserLoginOutputDto>();

            CreateMap<User, GetUseroutputDto>()
                .ForMember(o => o.FullName, x => x.MapFrom(o => o.FullName))
                .ForMember(o => o.FavorateCategory, x => x.MapFrom(o => o.FavoriteCategory))
                .ForMember(o => o.FavorateCountry, x => x.MapFrom(o => o.FavoriteCountry))
                .ForMember(o => o.PhoneNumber, x => x.MapFrom(o => o.PhoneNumber));

            CreateMap<Comment, GetCommentOutputDto>()
                .ForMember(o => o.Text, x => x.MapFrom(o => o.Text))
                .ForMember(o=>o.TuristPlaceName,x=>x.MapFrom(o=>o.TuristPlace.Name))
                .ForMember(o => o.UserName, x => x.MapFrom(o => o.User.UserName));

            CreateMap<Comment, GetPlacecommentsOutputDto>()
                .ForMember(o => o.Text, x => x.MapFrom(o => o.Text))
                .ForMember(o => o.RecordTime, x => x.MapFrom(o => o.RecordDate))
                .ForMember(o => o.UserName, x => x.MapFrom(o => o.User.UserName));

            CreateMap<Comment, GetCoomentOutputDto>()
                .ForMember(o => o.Text, x => x.MapFrom(o => o.Text))
                .ForMember(o => o.UserName, x => x.MapFrom(o => o.User.UserName))
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(o => o.TuristPlace.Name));

            CreateMap<Rate, GetRateOutputDto>()
                .ForMember(o => o.TueistPlace, x => x.MapFrom(o => o.TuristPlace.Name))
                .ForMember(o => o.UserName, x => x.MapFrom(o => o.User.UserName))
                .ForMember(o => o.UserRate, x => x.MapFrom(o => o.UserRate));

            CreateMap<Rate, GetPlaceRatesOutputDto>()
                 .ForMember(o => o.UserName, x => x.MapFrom(o => o.User.UserName))
                .ForMember(o => o.UserRate, x => x.MapFrom(o => o.UserRate));

            CreateMap<Category, GetCategoryOutputDto>()
                .ForMember(o => o.Name, x => x.MapFrom(o => o.Name))
                .ForMember(o => o.PlaceWithThisCategory, x => x.MapFrom(o => o.TuristPlaceCategory.Count));

            CreateMap<Category, GetPlaceCategoryOutputDto>()
                .ForMember(o => o.Name, x => x.MapFrom(o => o.Name));

            CreateMap<City, GetCityOutputDto>()
                .ForMember(o => o.City, x => x.MapFrom(o => o.Name))
                .ForMember(o => o.Country, x => x.MapFrom(o => o.Country.Name))
                .ForMember(o => o.TuristPlaces, x => x.MapFrom(o => o.TuristPlaces.Count));

            CreateMap<Country, GetCountryOutputDto>()
                .ForMember(o => o.Name, x => x.MapFrom(o => o.Name))
                .ForMember(o => o.Cities, x => x.MapFrom(o => o.Cities.Count))
                .ForMember(o => o.TuristPlaces, x => x.MapFrom(o => o.TuristPlaces.Count));

            CreateMap<TuristPlace, GetPlaceOutputDto>()
                 .ForMember(o => o.Name, x => x.MapFrom(o => o.Name))
                 .ForMember(o => o.City, x => x.MapFrom(o => o.City.Name))
                 .ForMember(o => o.Country, x => x.MapFrom(o => o.Country.Name))
                 .ForMember(o => o.Comments, x => x.MapFrom(o => o.Comments.Count))
                 .ForMember(o => o.Rates, x => x.MapFrom(o => o.Rates.Count))
                 .ForMember(o => o.Categories, x => x.MapFrom(o => o.TuristPlaceCategory.Count));

            CreateMap<TuristPlace, CategoryOutputDto>()
                .ForMember(o => o.TuristPlaceId, x => x.MapFrom(p => p.Id));

            CreateMap<TuristPlace, CountryOutPutDto>()
                .ForMember(o => o.TuristPlaceId, x => x.MapFrom(p => p.Id));



            CreateMap<TuristPlace, TuristPlaceOutputDto>()
                .ForMember(o => o.id, x => x.MapFrom(p => p.Id))
                .ForMember(o => o.Image, x => x.MapFrom(p => p.Image))
                .ForMember(o => o.Name, x => x.MapFrom(p => p.Name))
                .ForMember(o => o.CommentsNumber, x => x.MapFrom(p => p.Comments.Count))
                .ForMember(o => o.AverageRates, x => x.MapFrom(p => p.Rates.Average(r => r.UserRate)))
                .ForMember(o => o.Description, x => x.MapFrom(p => p.Description))
                .ForMember(o => o.Visit, x => x.MapFrom(p => p.Visit));
               


            CreateMap<TuristPlace, VisitOutputDto>()
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(p => p.Name))
                .ForMember(o => o.CityName, x => x.MapFrom(p => p.City.Name))
                .ForMember(o => o.CountryName, x => x.MapFrom(p => p.Country.Name));

            CreateMap<TuristPlace, ViewOutputDto>()
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(p => p.Name))
                .ForMember(o => o.Id, x => x.MapFrom(p => p.Id))
                .ForMember(o => o.Image, x => x.MapFrom(p => p.Image));

            CreateMap<TuristPlace, PopularOutputDto>();

            CreateMap<TuristPlace, FilterOutputDetailDTO>()
               .ForMember(o => o.TuristPlaceName, x => x.MapFrom(p => p.Name))
               .ForMember(o => o.Country, x => x.MapFrom(p => p.Country.Name))
               .ForMember(o => o.City, x => x.MapFrom(p => p.City.Name));

            CreateMap<TuristPlace, FavoroteOutputDto>()
                .ForMember(o => o.id, x => x.MapFrom(p => p.Id))
                .ForMember(o => o.Image, x => x.MapFrom(p => p.Image))
                .ForMember(o => o.Name, x => x.MapFrom(p => p.Name))
                .ForMember(o => o.Description, x => x.MapFrom(p => p.Description))
                .ForMember(o => o.AverageRates, x => x.MapFrom(p => p.Rates.Average(x=>x.UserRate)))
                .ForMember(o => o.CommentsNumber, x => x.MapFrom(p => p.Comments.Count))
                .ForMember(o => o.Visit, x => x.MapFrom(p => p.Visit));

            CreateMap<TuristPlace,NewInputDTO>()
                .ForMember(o => o.Description, x => x.MapFrom(o => o.Description))
                .ForMember(o => o.Id, x => x.MapFrom(o => o.Id))
                .ForMember(o => o.Image, x => x.MapFrom(o => o.Image))
                .ForMember(o => o.TuristPlaceName, x => x.MapFrom(o => o.Name));


        }
    }
}
