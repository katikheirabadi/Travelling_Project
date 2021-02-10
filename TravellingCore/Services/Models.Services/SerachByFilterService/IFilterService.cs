using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.SearchByFilter;

namespace TravellingCore.Services.Models.Services.SerachByFilterService
{
    public interface IFilterService
    {
        public FilterOutputDTO SearchByFilter(FilterInputDTO filterInputDTO);
    }
}
