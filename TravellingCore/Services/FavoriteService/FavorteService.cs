using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Favorites;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Exceptions;
using TravellingCore.Model;

namespace TravellingCore.Services.FavoriteService
{
    public class FavorteService : IFavoriteService
    {
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository;
        private readonly UserManager<User> userManager;
        private readonly IRepository<Comment> commentrepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IMapper mapper;
        public FavorteService(IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository
                              ,UserManager<User> userManager
                              ,IRepository<Comment> Commentrepository
                              ,IRepository<TuristPlace> TuristPlaceRepository
                              ,IMapper mapper)
        {
            this.TuristPlaceCategoryRepository = TuristPlaceCategoryRepository;
            this.userManager = userManager;
            commentrepository = Commentrepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.mapper = mapper;
        }
        private List<FilterOutputDetailDTO> ConCat(List<FilterOutputDetailDTO> First , List<FilterOutputDetailDTO> Secend)
        {
            var add = false;
            foreach (var item in Secend)
            {
                if (First.Count == 0)
                    First.Add(item);
                else
                {
                    foreach (var item2 in First)
                    {
                        if (item.id != item2.id)
                            add = true;
                        else
                            add = false;
                    }
                    if (add)
                        First.Add(item);
                }
            }
            return First;
        }
        private List<FilterOutputDetailDTO> RecommendedByCountry(User User)
        {
            return TuristPlaceRepository.GetQuery().Include(c => c.Country)
                                                .Include(p => p.Rates)
                                                .Include(p => p.Comments)
                                                .Where(p => p.CountryId == User.FavoriteCountry)
                                                .Select(p => mapper.Map<FilterOutputDetailDTO>(p)).ToList();
        }
        private List<FilterOutputDetailDTO> RecommendedByCategory(User User)
        {
            var places = TuristPlaceRepository.GetQuery().Include(c => c.Country)
                                                .Include(p => p.Rates)
                                                .Include(p => p.Comments)
                                                .Select(p => mapper.Map<FilterOutputDetailDTO>(p)).ToList();
            var placescategories = TuristPlaceCategoryRepository.GetQuery().Include(tc => tc.Categories)
                                                           .Include(tc => tc.TuristPlaces)
                                                           .Where(tc => tc.CategoryId == User.FavoriteCategory)
                                                           .Select(tc => tc.TuristPlaceId).ToList();
            return places.Where(p => placescategories.Contains(p.id)).ToList();                                         
        }
        public async Task<List<FilterOutputDetailDTO>> ReccomendedByFavorite(string UserId)
        {
            var user = await userManager.FindByIdAsync(UserId);
            var recommended = new List<FilterOutputDetailDTO>();
            if (user.FavoriteCategory != null)
            {
                var categoryrecommended = RecommendedByCategory(user);
                recommended = ConCat(recommended, categoryrecommended);
            }
            if (user.FavoriteCountry != null)
            {
                var countryrecommended = RecommendedByCountry(user);
                recommended = ConCat(recommended, countryrecommended);
            }
            if (recommended.Count==0)
                throw new KeyNotFoundException("remommended is null");

            return recommended;

        }
    }
}
