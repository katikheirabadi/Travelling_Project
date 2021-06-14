using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Compare;

namespace TravellingCore.Services.Models.Services.CompareService
{
    public interface ICompareService
    {
        public Task<CompareOutputDto> Compare(CompareInputDTO compareInput);
    }
}
