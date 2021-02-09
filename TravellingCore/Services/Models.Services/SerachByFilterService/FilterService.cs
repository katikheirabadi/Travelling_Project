using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.SerachByFilterService
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<TuristPlace> repository;
        private readonly IRepository<TuristPlaceCategory> rep;
        private readonly IMapper mapper;
        public FilterService(IRepository<TuristPlace> repository, IRepository<TuristPlaceCategory> rep, IMapper mapper)
        {
            this.repository = repository;
            this.rep = rep;
            this.mapper = mapper;
        }
        public FilterOutputDTO SearchByFilter(FilterInputDTO filterInputDTO)
        {
            var first = repository.GetQuery()
                .Include(x => x.Country)
                .ThenInclude(x => x.TuristPlaces)
                .Where(y => y.Country.Name.Contains(filterInputDTO.Country));

            var second = first
                .Include(x => x.City)
                .ThenInclude(x => x.TuristPlaces)
                .Where(x => x.City.Name.Contains(filterInputDTO.City));

            var third = rep.GetQuery()
                .Include(x => x.Categories)
                .Include(x => x.TuristPlaces)
                .Where(x => x.Categories.Name.Contains(filterInputDTO.Category)).Select(x => x.TuristPlaces);

            var finall = (from a in first join b in second on a.Id equals b.Id select b).ToList();
            var result = mapper.Map<List<FilterOutputDetailDTO>>(finall);

            return new FilterOutputDTO()
            { 
                Places = result.ToArray()
            };
        }
    }
}
