using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Rate;
using TravellingCore.Dto.Rate.DeleteRate;
using TravellingCore.Dto.Rate.GetAll;
using TravellingCore.Dto.Rate.GetPlaceRates;
using TravellingCore.Dto.Rate.GetRate;
using TravellingCore.Dto.Rate.UpdateRate;
using TravellingCore.Exceptions;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services;
using TravellingCore.Services.Models.Services.RateService;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class RateService : IRateService
    {
        private readonly IRepository<Rate> RateRepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public RateService(IRepository<Rate> RateRepository,
                          IRepository<TuristPlace> TuristPlaceRepository,
                          IMapper mapper,
                          UserManager<User> userManager)
        {
            this.RateRepository = RateRepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
      
       
        private TuristPlace FindPlace(string place)
        {
            var places = TuristPlaceRepository.GetQuery();
            var findplace = places.FirstOrDefault(p => p.Name == place);

            if (findplace == null)
                throw new KeyNotFoundException("Not found place with this name");

            return findplace;
        }
        private async Task<Rate> FindRate(int id)
        {
            var rates = await RateRepository.GetAll();
            var findrate = rates.FirstOrDefault(r => r.Id == id);

            if (findrate == null)
                throw new KeyNotFoundException("Not Found Rate with this id ");

            return findrate;
        }
        public async Task<string> AddRate(RateInputDto  rate)
        {
            var places = await TuristPlaceRepository.GetAll();
            var place = places.Find(p => p.Id == rate.place);
            try
            {
                var user = await userManager.FindByIdAsync(rate.UserId);
                RateRepository.Insert(new Rate()
                {
                    RecordDate = DateTime.Now,
                    UserRate = rate.Rate,
                    TuristPlaceId = place.Id,
                    UserId = user.Id
                });
                await RateRepository.Save();
                return "we add your Rate .";
            }
            catch 
            {
                throw new KeyNotFoundException("not found this user");
            }
           
          }
        public async Task<GetRateOutputDto> GetRate(GetrateInputDto getinput)
        {
            var findrate = await FindRate(getinput.RateId);
            var endrate = RateRepository.GetQuery()
                                        .Include(r => r.User)
                                        .Include(r => r.TuristPlace)
                                        .FirstOrDefault(r => r.Id == findrate.Id);

            return mapper.Map<GetRateOutputDto>(endrate);

        }
        public async Task<List<GetRateOutputDto>> GetAllRate()
        {
            var rates = await RateRepository.GetAll();
            var endrates = RateRepository.GetQuery()
                                         .Include(r => r.User)
                                         .Include(r => r.TuristPlace)
                                         .Select(r=> mapper.Map<GetRateOutputDto>(r))
                                         .ToList();

            return endrates;

        }
        public  Task<List<GetPlaceRatesOutputDto>> GetAllRatesOfPlace(GetPlaceRatesInputDto getplaceinput)
        {
            var findplace = FindPlace(getplaceinput.Place);
            var rates = RateRepository.GetQuery()
                                      .Include(r => r.TuristPlace)
                                      .Include(r => r.User)
                                      .Where(r => r.TuristPlace.Name == getplaceinput.Place)
                                      .Select(r => mapper.Map<GetPlaceRatesOutputDto>(r))
                                      .ToListAsync();

            if (rates == null)
                throw new KeyNotFoundException("Not Found rate for this place");

            return rates;
        }
        public async Task<string> DeleteRate(DeleterateInputDto deleterateinput)
        {
            var result = RateRepository.Delete(deleterateinput.RateId);
            await RateRepository.Save();
            return result;
        }
        public async Task<string> UpdateRate(UpdateRateInputDto updateinput)
        {
            var findrate = await FindRate(updateinput.RateId);
            findrate.UserRate = updateinput.Rate;

            var result = RateRepository.Update(findrate);
            await RateRepository.Save();

            return result;
        }
        public async Task<List<GetAllOutPutDto>> GetAll()
        {
            var result1 = await RateRepository.GetAll();
            return result1.Select(r => new GetAllOutPutDto() { Id = r.Id, Rate = r.UserRate, UserId = r.UserId, PlaceId = r.TuristPlaceId })
                                 .ToList();
        }

    }
}
