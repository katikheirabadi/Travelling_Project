using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Favorites;
using TravellingCore.Exceptions;
using TravellingCore.Model;

namespace TravellingCore.Services.FavoriteService
{
    public class FavorteService : IFavoriteService
    {
        private readonly IRepository<UserLogin> UserLoginRepository;
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository;
        private readonly IMapper mapper;

        public FavorteService(IRepository<UserLogin> UserLoginRepository
                              ,IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository
                              ,IMapper mapper)
        {
            this.UserLoginRepository = UserLoginRepository;
            this.TuristPlaceCategoryRepository = TuristPlaceCategoryRepository;
            this.mapper = mapper;
        }
        private async Task<UserLogin> FindUserLogin(string Token)
        {
            var users = await UserLoginRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                throw new KeyNotFoundException("Not Found UserLogin");
            return user;
        }
        private void IsExpiresdToken(UserLogin user, string Token)
        {
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds <= 0)
                throw new ExpiredException("Yor Token Was Excpired");

        }
        private List<int?> GetFavorites(UserLogin userLogin)
        {
            var favorites = UserLoginRepository.GetQuery()
                                               .Include(u => u.user)
                                               .Where(u => u.Id == userLogin.Id)
                                               .FirstOrDefault();

            if (favorites.user.FavoriteCountry == null && favorites.user.FavoriteCategory == null)
                throw new KeyNotFoundException("You don't have any favorites");

            return new List<int?>() { favorites.user.FavoriteCategory, favorites.user.FavoriteCountry };
                                                          
        }
        public async Task<List<FavoroteOutputDto>> ReccomendedByFavorite(string Token)
        {
            var finduserlogin = await FindUserLogin(Token);
            IsExpiresdToken(finduserlogin, Token);

            var favorites = GetFavorites(finduserlogin);

            var reccomended = new List<int>();

            if (favorites[0] != null)
            {
                var result = TuristPlaceCategoryRepository.GetQuery()
                                                          .Include(p => p.TuristPlaces)
                                                          .Include(p => p.Categories)
                                                          .Where(p => p.Categories.Id == favorites[0])
                                                          .Select(p => p.TuristPlaces.Id)
                                                          .ToList();
                reccomended = result;
            }
            if (favorites[1] != null)
            {
                var result = TuristPlaceCategoryRepository.GetQuery()
                                                          .Include(p => p.TuristPlaces)
                                                          .ThenInclude(p => p.Country)
                                                          .Where(p => p.TuristPlaces.Country.Id == favorites[1])
                                                          .Select(p => p.TuristPlaces.Id)
                                                          .ToList();

                reccomended = reccomended.Concat(result).ToList();
            }

            if (reccomended == null)
                throw new KeyNotFoundException("Not Found Any Place With Your Favorites..");


            return reccomended.Select(p => mapper.Map<FavoroteOutputDto>(p)).ToList();

        }
    }
}
