using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.TuristPlaceCategory.GetAll;
using TravellingCore.Dto.TuristPlaceCategory.Regisster;

namespace TravellingCore.Services.Models.Services.TuristPlaceCategoryServise
{
    public interface ITuristPlaceCategoryServise
    {
        public Task<string> Register(RegisterInputDto registerinput);
        public Task<string> UnRegister(RegisterInputDto unregisterinput);
        public Task<List<GetturistPlaceOutputDto>> GetAll();
        public Task DeleteById(int Id);

    }
}
