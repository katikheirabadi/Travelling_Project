using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.ModelsServiceRepository.SigninRepository;
using TravellingCore.ServiceRepository.LoginService;
using TravellingCore.Services.LoginService;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.CityService;
using TravellingCore.Services.Models.Services.CommentServise;
using TravellingCore.Services.Models.Services.CountryService;
using TravellingCore.Services.Models.Services.CompareService;
using TravellingCore.Services.Models.Services.RateService;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;
using TravellingCore.Services.Models.Services.SearchServise;
using TravellingCore.Services.Models.Services.TuristPlaceService;
using TravellingCore.Services.SigninServicefoulder;
using TravellingEF.ContextRepository;
using TravellingCore.Services.FavoriteService;

namespace Travelling.Extention
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Comment>, Repository<Comment>>();
            services.AddTransient<IRepository<TuristPlace>, Repository<TuristPlace>>();
            services.AddTransient<IRepository<Rate>, Repository<Rate>>();
            services.AddTransient<IRepository<UserLogin>, Repository<UserLogin>>();
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<City>, Repository<City>>();
            services.AddTransient<IRepository<TuristPlaceCategory>, Repository<TuristPlaceCategory>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
        }
        private static void AddServices(IServiceCollection services)
        {
           
            services.AddTransient<ILoginServicecs, LoginServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginServicecs, LoginServices>();
            services.AddTransient<ICommentService, ComentService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<ITuristPlaceService, TuristPlaceService>();
            services.AddTransient<ICompareService, CompareService>();
            services.AddTransient<ISearchservise, SearchServise>();
            services.AddTransient<ICategoryServise,CategoryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ITuristPlaceCategoryServise, TuristPlaceCategoryServise>();
            services.AddTransient<IFavoriteService, FavorteService>();
        }
    }
}
