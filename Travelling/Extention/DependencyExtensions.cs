using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.ModelsServiceRepository.SigninRepository;

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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TravellingEF.DataBase;
using TravellingCore.Claims;

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
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            /*
            services.AddTransient<IRepository<Comment>, Repository<Comment>>();
            services.AddTransient<IRepository<TuristPlace>, Repository<TuristPlace>>();
            services.AddTransient<IRepository<Rate>, Repository<Rate>>();
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<City>, Repository<City>>();
            services.AddTransient<IRepository<TuristPlaceCategory>, Repository<TuristPlaceCategory>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            */
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserService, UserService>();
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
        public static void AddAspNetIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
           .AddEntityFrameworkStores<TravellingDBContext>()
           .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<User>,
             AdditionalUserClaimsPrincipalFactory>();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

        }
    }
}
