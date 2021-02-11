using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Rate;
using TravellingCore.Dto.Rate.DeleteRate;
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
        private readonly IRepository<UserLogin> UserLoginRepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IMapper mapper;

        public RateService(IRepository<Rate> RateRepository,
                          IRepository<UserLogin> UserLoginRepository, 
                          IRepository<TuristPlace> TuristPlaceRepository,
                          IMapper mapper)
        {
            this.RateRepository = RateRepository;
            this.UserLoginRepository = UserLoginRepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.mapper = mapper;
        }
        private async Task<UserLogin> FindUserLogin(string Token)
        {
            var users = await UserLoginRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                throw new KeyNotFoundException("Not Found  Login-user with this Token ");
            return user;
        }
        private void IsExpired(UserLogin user)
        {
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds <= 0)
               throw new ExpiredException("Token was expired"); 
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
        public async Task<string> AddRate(RateInputDto  rate , string Token)
        {
            var user = await FindUserLogin(Token);
            IsExpired(user);
            var place = FindPlace(rate.place);

            RateRepository.Insert(new Rate()
            {
                RecordDate = DateTime.Now,
                UserRate = rate.Rate,
                TuristPlaceId = place.Id,
                UserId = user.UserId
            }) ;
            await RateRepository.Save();


            return "we add your Rate .";
          }
        public async Task<GetRateOutputDto> GetRate(GetrateInputDto getinput)
        {
            var findrate = await FindRate(getinput.RateId);
            var endrate = RateRepository.GetQuery().Include(r => r.User)
                                                    .Include(r => r.TuristPlace)
                                                    .FirstOrDefault(r => r.Id == findrate.Id);
            return mapper.Map<GetRateOutputDto>(endrate);

        }
        public async Task<List<GetRateOutputDto>> GetAllRate()
        {
            var rates = await RateRepository.GetAll();
            var endrates = RateRepository.GetQuery().Include(r => r.User)
                                                   .Include(r => r.TuristPlace)
                                                   .Select(r=> mapper.Map<GetRateOutputDto>(r)).ToList();
            return endrates;

        }
        public  Task<List<GetPlaceRatesOutputDto>> GetAllRatesOfPlace(GetPlaceRatesInputDto getplaceinput)
        {
            var findplace = FindPlace(getplaceinput.Place);
            var rates = RateRepository.GetQuery().Include(r => r.TuristPlace)
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

    }
}
