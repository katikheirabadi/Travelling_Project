using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto._ُSearchByCategory;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Dto.SearchByTuristPlaceName;

namespace TravellingCore.Services.Models.Services.SearchServise
{
    public interface ISearchservise
    {
        public FilterOutputDTO SearchByFilter(FilterInputDTO filterInputDTO);
        public Task<List<CategoryOutputDto>> SearchByCategory(CategoryInputDto category);
        public Task<List<CountryOutPutDto>> SearchByCountry(CountryInputDto country);
        public Task<CityListOutputDTO> SearchbyCity(string city);
        public Task<TuristPlaceOutputDto> SearchByName(TuristPlaceInputDto turistPlace);
    }
}
