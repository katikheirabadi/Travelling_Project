using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Favorites;
using TravellingCore.Dto.SearchByFilter;

namespace TravellingCore.Services.FavoriteService
{
    public interface IFavoriteService
    {
        public Task<List<FilterOutputDetailDTO>> ReccomendedByFavorite(string UserId);
    }
}
