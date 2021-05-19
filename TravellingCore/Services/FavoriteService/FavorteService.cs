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
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository;
        private readonly IMapper mapper;

        public FavorteService(IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository
                              ,IMapper mapper)
        {
            this.TuristPlaceCategoryRepository = TuristPlaceCategoryRepository;
            this.mapper = mapper;
        }
        public async Task<List<FavoroteOutputDto>> ReccomendedByFavorite(string Token)
        {
        //    var finduserlogin = await FindUserLogin(Token);
        //    IsExpiresdToken(finduserlogin, Token);

        //    var favorites = GetFavorites(finduserlogin);

        //    var reccomended = new List<TuristPlace>();

        //    if (favorites[0] != null)
        //    {
        //        var result = TuristPlaceCategoryRepository.GetQuery()
        //                                                  .Include(p => p.TuristPlaces)
        //                                                  .ThenInclude(p=>p.Comments)
        //                                                  .Include(p => p.Categories)
        //                                                  .Where(p => p.Categories.Id == favorites[0])
        //                                                  .Select(p => p.TuristPlaces)
        //                                                  .Include(p=>p.Rates)
        //                                                  .ToList();
        //        reccomended = result;
        //    }
        //    if (favorites[1] != null)
        //    {
        //        var result = TuristPlaceCategoryRepository.GetQuery()
        //                                                  .Include(p => p.TuristPlaces)
        //                                                  .ThenInclude(p => p.Country)
        //                                                  .Where(p => p.TuristPlaces.Country.Id == favorites[1])
        //                                                  .Select(p => p.TuristPlaces)
        //                                                  .Include(p=>p.Rates)
        //                                                  .ToList();

        //        reccomended = reccomended.Concat(result).ToList();
        //    }

        //    if (reccomended == null)
        //        throw new KeyNotFoundException("شما علاقه مندی در ثبت نام خود انتخاب نکردی");


            return null; //reccomended.Select(p => mapper.Map<FavoroteOutputDto>(p)).ToList();

        }
    }
}
