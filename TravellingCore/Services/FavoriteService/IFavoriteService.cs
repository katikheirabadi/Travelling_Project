using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Favorites;

namespace TravellingCore.Services.FavoriteService
{
    public interface IFavoriteService
    {
        public Task<List<FavoroteOutputDto>> ReccomendedByFavorite(string Token);
    }
}
